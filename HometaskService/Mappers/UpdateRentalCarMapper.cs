using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;

namespace HometaskService.Mappers
{
    public class UpdateRentalCarMapper : IMapper<UpdateRentalCarRequest, DbRentalCar>
    {
        public DbRentalCar Map(UpdateRentalCarRequest car)
        {
            if (car is null)
            {
                return null;
            }

            return new DbRentalCar()
            {
                Id = car.Id,
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
