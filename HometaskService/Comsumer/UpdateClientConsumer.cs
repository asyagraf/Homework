using CarRentalService.Request;
using FluentValidation;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class UpdateClientConsumer : IConsumer<UpdateClientRequest>
    {
        private readonly IRentalRepository<DbClient> repository;
        private readonly IMapper<UpdateClientRequest, DbClient> mapper;
        private readonly IValidator<UpdateClientRequest> validator;
        public UpdateClientConsumer(IRentalRepository<DbClient> repository, IMapper<UpdateClientRequest, DbClient> mapper,
            IValidator<UpdateClientRequest> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task Consume(ConsumeContext<UpdateClientRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var client = mapper.Map(context.Message);
                await repository.Update(client);
                await context.RespondAsync(new CUDClientResponse() { Result = "Updated" });
            }
            catch
            {
                await context.RespondAsync(new CUDClientResponse() { Result = "Can't be updated" });
            }
        }
    }
}
