using Mark3.Data.Tables;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mark4.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PortfolioTable1>()
                .HasOne(c => c.UserTable1)
                .WithMany(u => u.PortfolioTable1s)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PortfolioTable1>()
                .HasOne(c => c.InstrumentTable1)
                .WithMany(u => u.PortfolioTable1s)
                .HasForeignKey(c => c.InstrumentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FeedTable1>()
                .HasOne(c => c.InstrumentTable1)
                .WithMany(u => u.FeedTable1s)
                .HasForeignKey(c => c.InstrumentId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstrumentTable1>()
                .HasOne(c => c.ExchangeTable1)
                .WithMany(u => u.InstrumentTable1s)
                .HasForeignKey(c => c.ExchangeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTable1>()
                .HasOne(c => c.ExchangeTable1)
                .WithMany(u => u.UserTable1s)
                .HasForeignKey(c => c.ExchangeId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserTable1>()
                .HasOne(c => c.SetupTable1)
                .WithOne(u => u.UserTable1)
                .HasForeignKey<SetupTable1>(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InstrumentTable1>()
                .HasOne(c => c.WatchlistTable1)
                .WithOne(u => u.InstrumentTable1)
                .HasForeignKey<WatchlistTable1>(c => c.InstrumentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
        public DbSet<Mark3.Data.Tables.PortfolioTable1> PortfolioTable1 { get; set; } = default!;
    }
}
