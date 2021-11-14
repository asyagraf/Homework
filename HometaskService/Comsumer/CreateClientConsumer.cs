using CarRentalService.Request;
using FluentValidation;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class CreateClientConsumer : IConsumer<CreateClientRequest>
    {
        private readonly IRentalRepository<DbClient> repository;
        private readonly IMapper<CreateClientRequest, DbClient> mapper;
        private readonly IValidator<CreateClientRequest> validator;
        public CreateClientConsumer(IRentalRepository<DbClient> rep, IMapper<CreateClientRequest, DbClient> map,
            IValidator<CreateClientRequest> val)
        {
            repository = rep;
            mapper = map;
            validator = val;
        }
        public async Task Consume(ConsumeContext<CreateClientRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var client = mapper.Map(context.Message);
                await repository.Create(client);
                await context.RespondAsync(new CUDClientResponse() { Result = "Created" });
            }
            catch
            {
                await context.RespondAsync(new CUDClientResponse() { Result = "Can't be created" });
            }
        }
    }
}
