using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class AllRentalCarsConsumer : IConsumer<AllRentalCarsRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        private readonly IMapper<DbRentalCar, RentalCarResponse> mapper;
        public AllRentalCarsConsumer(IRentalRepository<DbRentalCar> repository, IMapper<DbRentalCar, RentalCarResponse> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Consume(ConsumeContext<AllRentalCarsRequest> context)
        {
            var cars = await repository.GetAll();
            await context.RespondAsync(cars.Select(car => mapper.Map(car)).ToList());
        }
    }
}
