using CarRentalService.Request;
using FluentValidation;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class CreateRentalCarConsumer : IConsumer<CreateRentalCarRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        private readonly IMapper<CreateRentalCarRequest, DbRentalCar> mapper;
        private readonly IValidator<CreateRentalCarRequest> validator;
        public CreateRentalCarConsumer(IRentalRepository<DbRentalCar> repository, IMapper<CreateRentalCarRequest, DbRentalCar> mapper,
            IValidator<CreateRentalCarRequest> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task Consume(ConsumeContext<CreateRentalCarRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var car = mapper.Map(context.Message);
                await repository.Create(car);
                await context.RespondAsync(new CUDRentalCarResponse() { Result = "Created" });
            }
            catch
            {
                await context.RespondAsync(new CUDRentalCarResponse() { Result = "Can't be created" });
            }
        }
    }
}
