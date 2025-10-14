## Mark4


```
Close all Visual Studio Instances running in your machine. Also, make sure devenv.exe is not running in the Task Manager.
Delete the Component cache directory C:\%USERPROFILE%\AppData\Local\Microsoft\VisualStudio\1x.0\ComponentModelCache

Run the below command after deleting the files from the above folders,
cd C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\ 
.\devenv.exe /ResetUserData
VS Login

Create new project >> Blazor web app
Project name
Select Path
Put project and solution in same folder
Framewotk = .Net8 Long term support
Auth type = Individual account
Intractive render mode = Auto (Server and web assembly)
Intractive location = Per page/component
Git login
Git push

Open >> appsettings.json >> DefaultConnection >> Enter database name >> Save
View >> SQL server object explorer >> Databases >> Create new DB (optional)

Tools >> Nuget package manager >> Package manager console
PM> Add-Migration [migration name]
PM> Remove-Migration  //To undo this action
PM> Update-Database
Git push

```


### Azure deployment
```
[0] Subscription = Select your free or default subscription
[0] Resource Group = Click “Create new” 

[0] Azure SQL Database Server
[1] Server: Click “Create new”
[2] Choose SQL Authentication
[3] Create admin credentials (do not use @domain.com)
[4] Allow Azure services to access the server
[5] Set up firewall rules to allow Azure services and your IP.

[0] Create Database
[1] Select a fixed number of vCores or DTUs 
[2] Disable auto scaling 
[3] Backup storage redundancy section = Locally Redundant Backup (LRS)
[4] Keep logging in your app to Warning or higher in production
[5] Select same region for all services

[0] Go to your SQL Database >> Connection Strings
[1] Copy the ADO.NET connection string
[2] Replace your_user and your_password with the admin login credentials you created
[3] Update environment variables in production

[0] Azure SignalR Service (Free Tier)
[1] Service Mode = Default
[2] Leave Public access enabled (default)
[3] Go to your SignalR resource >> Keys in the left menu
[4] Copy the connection string for use in your app.
[5] Update environment variables in production

[0] Azure App Service (Linux B1)
[1] Go to Azure Portal >> Create a Web App.
[2] Publish = Code
[3] Runtime stack = .NET 8
[4] Operating system = Linux
[5] Configure domain and Enable = HTTPS only

[0] Update environment variables in production
[1] Go to App Service >> Configuration >> Application Settings
[2] ASPNETCORE_ENVIRONMENT = Production
[3] Azure__SignalR__ConnectionString = <your-signalr-connection-string>
[4] ConnectionStrings__DefaultConnection = <your-sql-connection-string>
[5] Azure__UseAzureSignalR = true
[6] Azure__UseMigrate = true

[0] Go to your repo >> Settings >> Secrets >> Actions
[1] Go to App Service >> Overview >> Click “Get Publish Profile”
[2] Download the .PublishSettings file
[3] Go to your repo >> Settings >> Secrets >> Actions
[4] Add a new secret >> Name = AZURE_PUBLISH_PROFILE
[5] Value = Paste the entire contents of the .PublishSettings file
[6] App Services >> Overview tab >> the name at the top is your App Service name
[7] app-name = YOUR_AZURE_APP_NAME

[0] Go to App Service >> Custom Domains >> Add Custom Domain
[1] Enter domainname.com
[2] Copy the IP address shown there (you’ll need it for domain provider)
[3] Don’t click “Validate” yet

[0] Verify ownership via DNS TXT record
[1] Log in to your Domain Provider dashboard >> DNS tab for domainname.com
[2] Delete existing "A" Record

```

| Type		| Host	| Value				|
| --------------- |:---------:|:---------------------------:|
| A			| @		| 10:192:100:100			|
| TXT			| asuid	| 1abcdef2ghijk3lm...		|

```
[3] Content = Paste the Domain Verification ID from Azure
[4] TTL = Auto or 5 minutes
[5] Proxy status = DNS only (Optional)
[0] Add a TXT Record (for domain verification)
[1] TXT = asuid.domainname.com >> Verification code from Azure (shown during domain setup)

[0] If the TXT record has propagated, Azure will confirm ownership
[1] TXT records can take a few minutes to propagate = 5–10 minutes
[2] Go back to Azure >> App Service >> Custom Domains
[3] Click Add Domain to complete the binding
[4] Click “Validate”

[0] Enable Use App Service Managed Certificate
[1] This will auto trigger TLS/SSL Bindings 

[0] Manual = Go to your App Service >> TLS/SSL Settings 
[1] Click Certificates (Preview) >> Create App Service Managed Certificate
[2] Select your custom domain (e.g., yourdomain.com)
[3] Click Create
[0] Go to TLS/SSL Bindings
[1] Click Add TLS/SSL Binding
[2] Choose your domainname.com and the managed certificate
[3] Set TLS/SSL Type to SNI SSL
[4] Click Add Binding
[0] Go to App Service >> TLS/SSL Settings
[1] Toggle HTTPS Only to On

[0] In Domain Provider portal >> Go to SSL/TLS tab (Optional)
[1] Set SSL mode to Full (Strict) for end-to-end encryption

[0] Navigate to Monitoring >> App Service logs
[1] Turn on = Application Logging (Filesystem)
[2] set to Information (or match your config)
[0] Open KUDU Console
[1] Go to Development Tools >> Advanced Tools >> Use link 
[0] Monitor logs via Azure App Service >> Log Stream

[0] Go to Cost Management + Billing
[1] Scope = Select the subscription, or billing account
[2] In the left-hand menu, click Budgets
[3] Fill in Budget Details
[4] Filters (optional) = by service, tag, or department
[5] Set Alert Thresholds
[6] Specify email recipients for alerts
[7] Click Create

```






