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
        public string Get([FromQuery] int id)
        {
            IGetPersonCommand command = new GetPersonCommand(new PersonRepository());
            return command.Execute(id);
        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            IGetAllPersonsCommand command = new GetAllPersonsCommand(new PersonRepository());
            return command.Execute();
        }

        [HttpPost]
        public void Create([FromBody] Person person)
        {
            ICreatePersonCommand command = new CreatePersonCommand(new PersonRepository());
            command.Execute(person);
        }

        [HttpPut]
        public void Update([FromBody] Person person)
        {
            IUpdatePersonCommand command = new UpdatePersonCommand(new PersonRepository());
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
