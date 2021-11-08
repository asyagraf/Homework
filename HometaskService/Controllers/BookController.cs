using HometaskService.Commands.Interfaces;
using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HometaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        [HttpGet("one")]
        public BookDTO Get([FromServices] IGetBookCommand command, [FromQuery] int id)
        {
            return command.Execute(id);
        }

        [HttpGet("all")]
        public List<BookDTO> GetAll([FromServices] IGetAllBooksCommand command)
        {
            return command.Execute();
        }

        [HttpPost]
        public void Create([FromServices] ICreateBookCommand command, [FromBody] BookDTO book)
        {
            command.Execute(book);
        }

        [HttpPut]
        public void Update([FromServices] IUpdateBookCommand command, [FromBody] DBBook book)
        {
            command.Execute(book);
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteBookCommand command, [FromQuery] int id)
        {
            command.Execute(id);
        }
    }
}
