using CarRentalService.Request;
using FluentValidation;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class ClientConsumer : IConsumer<ClientRequest>
    {
        private readonly IRentalRepository<DbClient> repository;
        private readonly IMapper<DbClient, ClientResponse> mapper;
        private readonly IValidator<ClientRequest> validator;
        public ClientConsumer(IRentalRepository<DbClient> rep, IMapper<DbClient, ClientResponse> map, IValidator<ClientRequest> val)
        {
            repository = rep;
            mapper = map;
            validator = val;
        }
        public async Task Consume(ConsumeContext<ClientRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var id = context.Message.Id;
                var client = await repository.GetById(id);
                var clientResp = mapper.Map(client);
                if (clientResp is not null)
                {
                    await context.RespondAsync(clientResp);
                }
                else
                {
                    await context.RespondAsync(new ClientResponse());
                }
            }
            catch
            {
                await context.RespondAsync(new ClientResponse());
            }
        }
    }
}
