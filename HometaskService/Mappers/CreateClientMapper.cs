using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;

namespace HometaskService.Mappers
{
    public class CreateClientMapper : IMapper<CreateClientRequest, DbClient>
    {
        public DbClient Map(CreateClientRequest client)
        {
            if (client is null)
            {
                return null;
            }

            return new DbClient()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                Experience = client.Experience
            };
        }
    }
}
