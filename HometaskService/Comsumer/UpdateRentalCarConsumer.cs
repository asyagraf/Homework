using CarRentalService.Request;
using FluentValidation;
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
        private readonly IValidator<UpdateRentalCarRequest> validator;
        public UpdateRentalCarConsumer(IRentalRepository<DbRentalCar> repository, IMapper<UpdateRentalCarRequest, DbRentalCar> mapper,
            IValidator<UpdateRentalCarRequest> validator)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.validator = validator;
        }
        public async Task Consume(ConsumeContext<UpdateRentalCarRequest> context)
        {
            try
            {
                validator.ValidateAndThrow(context.Message);
                var car = mapper.Map(context.Message);
                await repository.Update(car);
                await context.RespondAsync(new CUDRentalCarResponse() { Result = "Updated" });
            }
            catch
            {
                await context.RespondAsync(new CUDRentalCarResponse() { Result = "Can't be updated" });
            }
        }
    }
}
