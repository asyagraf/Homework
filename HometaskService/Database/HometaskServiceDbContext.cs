using HometaskService.DBModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HometaskService.Database
{
    internal class HometaskServiceDbContext : DbContext
    {
        public DbSet<DbRentalCar> RentalCars { get; set; }
        public DbSet<DbClient> Clients { get; set; }

        public HometaskServiceDbContext()
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ASYAGRAFPC\\SQLEXPRESS;Database=DBRental;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
