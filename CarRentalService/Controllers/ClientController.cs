using CarRentalService.Request;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarRentalService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        [HttpGet("one")]
        public async Task<ClientResponse> Get([FromServices] IRequestClient<ClientRequest> req, [FromQuery] int id)
        {
            return (await req.GetResponse<ClientResponse>(new ClientRequest() {Id = id})).Message;
        }

        [HttpGet("all")]
        public async Task<List<ClientResponse>> GetAll([FromServices] IRequestClient<AllClientsRequest> req)
        {
            return (await req.GetResponse<AllClientsResponse>(new AllRentalCarsRequest())).Message.Clients;
        }

        [HttpPost]
        public async Task Create([FromServices] IRequestClient<CreateClientRequest> req, [FromBody] CreateClientRequest create)
        {
            await req.GetResponse<CUDClientResponse>(create);
        }

        [HttpDelete]
        public async Task Delete([FromServices] IRequestClient<DeleteClientRequest> req, [FromQuery] int id)
        {
            await req.GetResponse<CUDClientResponse>(new RentalCarRequest() {Id = id});
        }

        [HttpPut]
        public async Task Update([FromServices] IRequestClient<UpdateClientRequest> req, [FromBody] UpdateClientRequest update)
        {
            await req.GetResponse<CUDClientResponse>(update);
        }
    }
}
