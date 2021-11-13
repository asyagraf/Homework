using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HometaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet("one")]
        public async Task<BookDTO> Get([FromServices] IGetBookCommand command, [FromQuery] int id)
        {
            return await command.ExecuteAsync(id);
        }

        [HttpGet("all")]
        public async Task<List<BookDTO>> GetAll([FromServices] IGetAllBooksCommand command)
        {
            return await command.ExecuteAsync();
        }

        [HttpPost]
        public async Task Create([FromServices] ICreateBookCommand command, [FromBody] BookDTO book)
        {
            await command.ExecuteAsync(book);
        }

        [HttpPut]
        public async Task Update([FromServices] IUpdateBookCommand command, [FromBody] DBBook book)
        {
            await command.ExecuteAsync(book);
        }

        [HttpDelete]
        public async Task Delete([FromServices] IDeleteBookCommand command, [FromQuery] int id)
        {
            await command.ExecuteAsync(id);
        }
    }
}
