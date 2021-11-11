using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.ModelsDTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HometaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        [HttpGet("one")]
        public CarDTO Get([FromServices] IGetCarCommand command, [FromQuery] string number)
        {
            return command.Execute(number);
        }

        [HttpGet("all")]
        public List<CarDTO> GetAll([FromServices] IGetAllCarsCommand command)
        {
            return command.Execute();
        }

        [HttpPost]
        public void Create([FromServices] ICreateCarCommand command, [FromBody] Car car)
        {
            command.Execute(car);
        }

        [HttpPut]
        public void Update([FromServices] IUpdateCarCommand command, [FromBody] Car car)
        {
            command.Execute(car);
        }

        [HttpDelete]
        public void Delete([FromServices] IDeleteCarCommand command, [FromQuery] string number)
        {
            command.Execute(number);
        }
    }
}
