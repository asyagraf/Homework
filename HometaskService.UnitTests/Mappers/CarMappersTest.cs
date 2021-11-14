using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using NUnit.Framework;

namespace HometaskService.UnitTests.Mappers
{
    class CarMappersTest
    {
        private IMapper<Car, CarDTO> mapperCarToCarDTO;

        private Car car;

        [SetUp]
        public void SetUp()
        {
            mapperCarToCarDTO = new CarMapper();

            car = new Car()
            {
                Owner = "Alex Green",
                Brand = "KIA",
                Model = "Rio",
                Number = "q123qw"
            };
        }

        [Test]
        public void ShouldReturnNullWhenCarIsNull()
        {
            var result = mapperCarToCarDTO.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnCarDTOWhenMappingValidCar()
        {
            var result = mapperCarToCarDTO.Map(car);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<CarDTO>(result);
        }
    }
}
