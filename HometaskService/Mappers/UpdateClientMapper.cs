using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;

namespace HometaskService.Mappers
{
    public class UpdateClientMapper : IMapper<UpdateClientRequest, DbClient>
    {
        public DbClient Map(UpdateClientRequest client)
        {
            if (client is null)
            {
                return null;
            }

            return new DbClient()
            {
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                Experience = client.Experience
            };
        }
    }
}
