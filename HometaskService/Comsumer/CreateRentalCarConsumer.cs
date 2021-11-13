using CarRentalService.Request;
using HometaskService.DBModels;
using HometaskService.Mappers.Interfaces;
using HometaskService.Repositories.Interfaces;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class CreateRentalCarConsumer : IConsumer<CreateRentalCarRequest>
    {
        private readonly IRentalRepository<DbRentalCar> repository;
        private readonly IMapper<CreateRentalCarRequest, DbRentalCar> mapper;
        public CreateRentalCarConsumer(IRentalRepository<DbRentalCar> repository, IMapper<CreateRentalCarRequest, DbRentalCar> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task Consume(ConsumeContext<CreateRentalCarRequest> context)
        {
            var car = mapper.Map(context.Message);
            await repository.Create(car);
            await context.RespondAsync("OK");
        }
    }
}
