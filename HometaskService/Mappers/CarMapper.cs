using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;

namespace HometaskService.Mappers
{
    public class CarMapper : IMapper<Car, CarDTO>
    {
        public CarDTO Map(Car car)
        {
            if (car is null)
            {
                return null;
            }

            return new CarDTO()
            {
                Brand = car.Brand,
                Model = car.Model,
                Number = car.Number
            };
        }
    }
}
