using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;

namespace HometaskService.Mappers
{
    public class RentalCarMapper : IMapper<DbRentalCar, RentalCarResponse>
    {
        public RentalCarResponse Map(DbRentalCar car)
        {
            if (car is null)
            {
                return null;
            }

            return new RentalCarResponse()
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
