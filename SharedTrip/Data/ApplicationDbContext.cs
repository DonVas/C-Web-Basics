using System.ComponentModel.DataAnnotations.Schema;
using SharedTrip.Models;

namespace SharedTrip
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>()
                .HasKey(k => new { k.UserId, k.TripId });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

    }
}
