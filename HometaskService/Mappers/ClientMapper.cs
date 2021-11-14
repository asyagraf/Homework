using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;

namespace HometaskService.Mappers
{
    public class ClientMapper : IMapper<DbClient, ClientResponse>
    {
        public ClientResponse Map(DbClient client)
        {
            if (client is null)
            {
                return null;
            }

            return new ClientResponse()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                Experience = client.Experience
            };
        }
    }
}
