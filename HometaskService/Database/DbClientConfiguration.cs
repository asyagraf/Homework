using HometaskService.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HometaskService.Database
{
    internal class DbClientConfiguration : IEntityTypeConfiguration<DbClient>
    {
        public void Configure(EntityTypeBuilder<DbClient> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(x => x.Id);
            builder.HasMany(client => client.RentalCars).WithOne(rentalCar => rentalCar.Client);
        }
    }
}
