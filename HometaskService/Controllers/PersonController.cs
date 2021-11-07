using HometaskService.Commands;
using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HometaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        [HttpGet("one")]
        public Person Get([FromServices] IGetPersonCommand command,[FromQuery] int id)
        {
            return command.Execute(id);
        }

        [HttpGet("all")]
        public List<Person> GetAll([FromServices] IGetAllPersonsCommand command)
        {
            return command.Execute();
        }

        [HttpPost]
        public void Create([FromServices] ICreatePersonCommand command, [FromBody] Person person)
        {
            command.Execute(person);
        }

        [HttpPut]
        public void Update([FromServices] IUpdatePersonCommand command, [FromBody] Person person)
        {
            command.Execute(person);
        }

        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            IDeletePersonCommand command = new DeletePersonCommand(new PersonRepository());
            command.Execute(id);
        }
    }
}
