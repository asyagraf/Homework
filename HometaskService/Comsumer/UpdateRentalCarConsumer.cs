using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class UpdateRentalCarConsumer : IConsumer<UpdateRentalCarRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        private readonly IMapper<UpdateRentalCarRequest, DbRentalCar> mapper;
        public UpdateRentalCarConsumer(IRentalRepository<DbRentalCar> repository, IMapper<UpdateRentalCarRequest, DbRentalCar> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Consume(ConsumeContext<UpdateRentalCarRequest> context)
        {
            var car = mapper.Map(context.Message);
            await repository.Update(car);
            await context.RespondAsync(new CUDRentalCarResponse() { Result = "Updated" });

        }
    }
}
