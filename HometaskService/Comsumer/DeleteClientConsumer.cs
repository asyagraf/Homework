using CarRentalService.Request;
using FluentValidation;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class DeleteClientConsumer : IConsumer<DeleteClientRequest>
    {
        private readonly IRentalRepository<DbClient> repository;
        private readonly IValidator<DeleteClientRequest> validator;
        public DeleteClientConsumer(IRentalRepository<DbClient> repository, IValidator<DeleteClientRequest> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
        public async Task Consume(ConsumeContext<DeleteClientRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var id = context.Message.Id;
                await repository.Delete(id);
                await context.RespondAsync(new CUDClientResponse() { Result = "Deleted" });
            }
            catch
            {
                await context.RespondAsync(new CUDClientResponse() { Result = "Can't be deleted" });
            }
        }
    }
}
