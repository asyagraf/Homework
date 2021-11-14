using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using NUnit.Framework;

namespace HometaskService.UnitTests.Mappers
{
    class RentalCarMappersTest
    {
        private IMapper<DbRentalCar, RentalCarResponse> mapperDbRentalCarToRentalCarResponse;
        private IMapper<CreateRentalCarRequest, DbRentalCar> mapperCreateRentalCarRequestToDbRentalCar;
        private IMapper<UpdateRentalCarRequest, DbRentalCar> mapperUpdateRentalCarRequestToDbRentalCar;

        private DbRentalCar car;
        private CreateRentalCarRequest createCar;
        private UpdateRentalCarRequest updateCar;

        [SetUp]
        public void SetUp()
        {
            mapperDbRentalCarToRentalCarResponse = new RentalCarMapper();
            mapperCreateRentalCarRequestToDbRentalCar = new CreateRentalCarMapper();
            mapperUpdateRentalCarRequestToDbRentalCar = new UpdateRentalCarMapper();

            car = new DbRentalCar();

            createCar = new CreateRentalCarRequest();

            updateCar = new UpdateRentalCarRequest();
        }

        #region IMapper<DbRentalCar, RentalCarResponse>
        [Test]
        public void ShouldReturnNullWhenDbRentalCarIsNull()
        {
            var result = mapperDbRentalCarToRentalCarResponse.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnRentalCarResponseWhenMappingValidDbRentalCar()
        {
            var result = mapperDbRentalCarToRentalCarResponse.Map(car);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RentalCarResponse>(result);
        }
        #endregion

        #region IMapper<CreateRentalCarRequest, DbRentalCar>
        [Test]
        public void ShouldReturnNullWhenCreateClientRequestIsNull()
        {
            var result = mapperCreateRentalCarRequestToDbRentalCar.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnDbRentalCarWhenMappingValidCreateRentalCarRequest()
        {
            var result = mapperCreateRentalCarRequestToDbRentalCar.Map(createCar);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<DbRentalCar>(result);
        }
        #endregion

        #region IMapper<UpdateRentalCarRequest, DbRentalCar>
        [Test]
        public void ShouldReturnNullWhenUpdateRentalCarRequestIsNull()
        {
            var result = mapperUpdateRentalCarRequestToDbRentalCar.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnDbRentalCarWhenMappingValidUpdateRentalCarRequest()
        {
            var result = mapperUpdateRentalCarRequestToDbRentalCar.Map(updateCar);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<DbRentalCar>(result);
        }
        #endregion
    }
}
