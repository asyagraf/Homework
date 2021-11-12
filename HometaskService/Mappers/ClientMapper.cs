using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.ModelsDTO;

namespace HometaskService.Mappers
{
    public class ClientMapper : IMapper<Client, ClientDTO>
    {
        public ClientDTO Map(Client client)
        {
            if (client is null)
            {
                return null;
            }

            return new ClientDTO()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                MiddleName = client.MiddleName,
                Experience = client.Experience
            };
        }
    }
}
