using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers;
using HometaskService.Mappers.Interfaces;
using NUnit.Framework;

namespace HometaskService.UnitTests.Mappers
{
    class ClientMappersTest
    {
        private IMapper<DbClient, ClientResponse> mapperDbClientToClientResponse;
        private IMapper<CreateClientRequest, DbClient> mapperCreateClientRequestToDbClient;
        private IMapper<UpdateClientRequest, DbClient> mapperUpdateClientRequestToDbClient;

        private DbClient client;
        private CreateClientRequest createClient;
        private UpdateClientRequest updateClient;

        [SetUp]
        public void SetUp()
        {
            mapperDbClientToClientResponse = new ClientMapper();
            mapperCreateClientRequestToDbClient = new CreateClientMapper();
            mapperUpdateClientRequestToDbClient = new UpdateClientMapper();

            client = new DbClient();

            createClient = new CreateClientRequest();

            updateClient = new UpdateClientRequest();
        }

        #region IMapper<DbClient, ClientResponse>
        [Test]
        public void ShouldReturnNullWhenDbClientIsNull()
        {
            var result = mapperDbClientToClientResponse.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnClientResponseWhenMappingValidDbClient()
        {
            var result = mapperDbClientToClientResponse.Map(client);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ClientResponse>(result);
        }
        #endregion

        #region IMapper<CreateClientRequest, DbClient>
        [Test]
        public void ShouldReturnNullWhenCreateClientRequestIsNull()
        {
            var result = mapperCreateClientRequestToDbClient.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnDbClientWhenMappingValidCreateClientRequest()
        {
            var result = mapperCreateClientRequestToDbClient.Map(createClient);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<DbClient>(result);
        }
        #endregion

        #region IMapper<UpdateClientRequest, DbClient>
        [Test]
        public void ShouldReturnNullWhenUpdateClientRequestIsNull()
        {
            var result = mapperUpdateClientRequestToDbClient.Map(null);
            Assert.IsNull(result);
        }

        [Test]
        public void ShouldReturnDbClientWhenMappingValidUpdateClientRequest()
        {
            var result = mapperUpdateClientRequestToDbClient.Map(updateClient);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<DbClient>(result);
        }
        #endregion
    }
}
