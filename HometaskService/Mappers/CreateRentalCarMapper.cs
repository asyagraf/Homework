using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;

namespace HometaskService.Mappers
{
    public class CreateRentalCarMapper : IMapper<CreateRentalCarRequest, DbRentalCar>
    {
        public DbRentalCar Map(CreateRentalCarRequest car)
        {
            if (car is null)
            {
                return null;
            }

            return new DbRentalCar()
            {
                Number = car.Number,
                IsAvailable = car.IsAvailable,
                Brand = car.Brand,
                Model = car.Model,
                Mileage = car.Mileage,
                ClientId = car.ClientId
            };
        }
    }
}
