using CarRentalService.Request;
using FluentValidation;
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
        private readonly IValidator<RentalCarRequest> validator;
        public RentalCarConsumer(IRentalRepository<DbRentalCar> repository, IMapper<DbRentalCar, RentalCarResponse> mapper,
            IValidator<RentalCarRequest> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task Consume(ConsumeContext<RentalCarRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var id = context.Message.Id;
                var car = await repository.GetById(id);
                var carResp = mapper.Map(car);
                if (carResp is not null)
                {
                    await context.RespondAsync(carResp);
                }
                else
                {
                    await context.RespondAsync(new RentalCarResponse());
                }
            }
            catch
            {
                await context.RespondAsync(new RentalCarResponse());
            }
        }
    }
}
