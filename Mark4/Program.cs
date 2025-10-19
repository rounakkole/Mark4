using Mark4.Client.Pages;
using Mark4.Components;
using Mark4.Components.Account;
using Mark4.Data;
using Mark4.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Azure.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, PersistingRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContextFactory<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));



// Azure SignalR service
// ToDo: Override in Azure App Service >> Configuration >> Application settings >> Azure__SignalR__ConnectionString
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSignalR(); // Local fallback
}
else if (builder.Configuration.GetValue<bool>("Azure:UseAzureSignalR"))
{
    // builder.Services.AddSignalR().AddAzureSignalR("Azure:SignalR:ConnectionString");
    builder.Services.AddSignalR()
        .AddAzureSignalR(options =>
        {
            options.ConnectionString = builder.Configuration["Azure:SignalR:ConnectionString"];
        });
}









builder.Services.AddQuickGridEntityFrameworkAdapter();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IFeedService, FeedService>();
builder.Services.AddScoped<ILoginUserService, LoginUserService>();
//builder.Services.AddHttpContextAccessor(); //ToDo: remove

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

if (!builder.Environment.IsDevelopment())
{
    // unable to connect to web server https. The web server is no longer running.
    // Add HSTS services
    builder.Services.AddHsts(options =>
    {
        options.Preload = true;
        options.IncludeSubDomains = true;
        options.MaxAge = TimeSpan.FromDays(365);
        //options.ExcludedHosts.Add("example.com");
        //options.ExcludedHosts.Add("www.example.com");
    });
}










var app = builder.Build();





// if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
if (builder.Configuration.GetValue<bool>("Azure:UseMigrate") || app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        try
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();
        }
        catch (Exception ex)
        {
            // Log the error, alert, or fallback
            Console.WriteLine($"Migration failed: {ex.Message}");
        }
    }
}





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting(); //added

//Configure your application startup by adding app.UseAuthorization() in the application startup code. If there are calls to app.UseRouting() and app.UseEndpoints(...), the call to app.UseAuthorization() must go between them.
app.UseAuthentication();
app.UseAuthorization();


app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Mark4.Client._Imports).Assembly);

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.MapFallbackToFile("index.html"); // For client-side routing fallback



app.Run();
