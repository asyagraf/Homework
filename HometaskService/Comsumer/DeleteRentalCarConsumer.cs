using CarRentalService.Request;
using FluentValidation;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class DeleteRentalCarConsumer : IConsumer<DeleteRentalCarRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        private readonly IValidator<DeleteRentalCarRequest> validator;
        public DeleteRentalCarConsumer(IRentalRepository<DbRentalCar> repository, IValidator<DeleteRentalCarRequest> validator)
        {
            this.repository = repository;
            this.validator = validator;
        }
        public async Task Consume(ConsumeContext<DeleteRentalCarRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var id = context.Message.Id;
                await repository.Delete(id);
                await context.RespondAsync(new CUDRentalCarResponse() { Result = "Deleted" });
            }
            catch
            {
                await context.RespondAsync(new CUDRentalCarResponse() { Result = "Can't be deleted" });
            }
        }
    }
}
