using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class DeleteRentalCarConsumer : IConsumer<DeleteRentalCarRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        public DeleteRentalCarConsumer(IRentalRepository<DbRentalCar> repository)
        {
            this.repository = repository;
        }
        public async Task Consume(ConsumeContext<DeleteRentalCarRequest> context)
        {
            var id = context.Message.Id;
            await repository.Delete(id);
            await context.RespondAsync("OK");
        }
    }
}
