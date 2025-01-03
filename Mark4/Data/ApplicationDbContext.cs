using Mark3.Data.Tables;
using Mark4.Data;
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
                .HasOne(c => c.ApplicationUser)
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

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(c => c.ExchangeTable1)
                .WithMany(u => u.ApplicationUsers)
                .HasForeignKey(c => c.ExchangeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(c => c.SetupTable1)
                .WithOne(u => u.ApplicationUser)
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
        public DbSet<Mark3.Data.Tables.InstrumentTable1> InstrumentTable1 { get; set; } = default!;
        public DbSet<Mark3.Data.Tables.FeedTable1> FeedTable1 { get; set; } = default!;
    }
}
