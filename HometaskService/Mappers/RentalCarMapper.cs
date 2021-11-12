using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;

namespace HometaskService.Mappers
{
    public class RentalCarMapper : IMapper<RentalCar, RentalCarDTO>
    {
        public RentalCarDTO Map(RentalCar rentalCar)
        {
            if (rentalCar is null)
            {
                return null;
            }

            return new RentalCarDTO()
            {
                Number = rentalCar.Number,
                IsAvailable = rentalCar.IsAvailable,
                Brand = rentalCar.Brand,
                Model = rentalCar.Model,
                Mileage = rentalCar.Mileage
            };
        }
    }
}
