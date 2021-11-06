using HometaskService.Models;
using HometaskService.Repositories;
using HometaskService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonRepository personRepository;
        public PersonController()
        {
            personRepository = new PersonRepository();
        }


        [HttpGet("one")]
        public string Get([FromQuery] int id)
        {
            return personRepository.GetById(id);
        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            return personRepository.GetAll();
        }

        [HttpPost]
        public void Create([FromBody] Person person)
        {
            personRepository.Create(person);
        }

        [HttpPut]
        public void Update([FromBody] Person person)
        {
            personRepository.Update(person);
        }

        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            personRepository.Delete(id);
        }
    }
}
