using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class RentalCarConsumer : IConsumer<RentalCarRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        private readonly IMapper<DbRentalCar, RentalCarResponse> mapper;
        public RentalCarConsumer(IRentalRepository<DbRentalCar> repository, IMapper<DbRentalCar, RentalCarResponse> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Consume(ConsumeContext<RentalCarRequest> context)
        {
            var id = context.Message.Id;
            var car = await repository.GetById(id);
            var carResp = mapper.Map(car);
            //await context.RespondAsync(mapper.Map(car));
            if (carResp is not null)
            {
                await context.RespondAsync(carResp);
            }
            else
            {
                //await context.RespondAsync(new RentalCarResponse()
                //{
                //    Number = "123QQQ",
                //    IsAvailable = true,
                //    Brand = "BMW",
                //    Model = "X6",
                //    Mileage = 200,
                //    ClientId = null
                //});
                await context.RespondAsync(new RentalCarResponse());
            }
        }
    }
}
