using HometaskService.Commands.Interfaces;
using HometaskService.Models;
using HometaskService.Repositories;
using HometaskService.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private ICarRepository carRepository;

        public CarController(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        [HttpGet("one")]
        public Car Get([FromServices] IGetCarCommand command, [FromQuery] string number)
        {
            return command.Execute(number);
        }

        [HttpGet("all")]
        public List<Car> GetAll([FromServices] IGetAllCarsCommand command)
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
