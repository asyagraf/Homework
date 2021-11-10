using HometaskService.DBModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HometaskService.Database
{
    internal class DbRentalCarConfiguration : IEntityTypeConfiguration<DbRentalCar>
    {
        public void Configure(EntityTypeBuilder<DbRentalCar> builder)
        {
            builder.ToTable("RentalCars");
            builder.HasKey(x => x.Id);
            builder.HasOne(rentalCar => rentalCar.Client).WithMany(client => client.RentalCars);
        }
    }
}
