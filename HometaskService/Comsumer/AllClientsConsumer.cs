using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class AllClientsConsumer : IConsumer<AllClientsRequest>
    {
        private readonly IRentalRepository<DbClient> repository;
        private readonly IMapper<DbClient, ClientResponse> mapper;
        public AllClientsConsumer(IRentalRepository<DbClient> repository, IMapper<DbClient, ClientResponse> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Consume(ConsumeContext<AllClientsRequest> context)
        {
            var cars = await repository.GetAll();
            var result = cars.Select(car => mapper.Map(car)).ToList();
            await context.RespondAsync(new AllClientsResponse() {Clients = result});
        }
    }
}
