using CarRentalService.Request;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalCarController : ControllerBase
    {
        [HttpGet("one")]
        public async Task<RentalCarResponse> Get([FromServices] IRequestClient<RentalCarRequest> req, [FromQuery] int id)
        {
            return (await req.GetResponse<RentalCarResponse>(new RentalCarRequest(){ Id = id })).Message;
        }

        [HttpGet("all")]
        public async Task<List<RentalCarResponse>> GetAll([FromServices] IRequestClient<AllRentalCarsRequest> req)
        {
            return (await req.GetResponse<List<RentalCarResponse>>(new AllRentalCarsRequest())).Message;
        }

        [HttpPost]
        public async Task Create([FromServices] IRequestClient<CreateRentalCarRequest> req, [FromBody] CreateRentalCarRequest create)
        {
            await req.GetResponse<string>(create);
        }

        [HttpDelete]
        public async Task Delete([FromServices] IRequestClient<DeleteRentalCarRequest> req, [FromQuery] int id)
        {
            await req.GetResponse<string>(new RentalCarRequest() { Id = id });
        }

        [HttpPut]
        public async Task Update([FromServices] IRequestClient<UpdateRentalCarRequest> req, [FromBody] UpdateRentalCarRequest update)
        {
            await req.GetResponse<string>(update);
        }
    }
}
