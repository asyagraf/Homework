using CarRentalService.Request;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Comsumer
{
    public class RentalCarConsumer : IConsumer<RentalCarRequest>
    {
        public async Task Consume(ConsumeContext<RentalCarRequest> context)
        {
            await context.RespondAsync(new RentalCarResponse
            {
                Number = "QQQQQQ",
                IsAvailable = true,
                Brand = "KIA",
                Model = "Rio",
                Mileage = 1,
                ClientId = null
            });
        }
    }
}
