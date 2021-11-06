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

        public CarController(IMemoryCache cache, List<string> keys)
        {
            carRepository = new CarRepository(cache, keys);
        }

        [HttpGet("one")]
        public string Get([FromQuery] string number)
        {
            return carRepository.GetByNumber(number);
        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            return carRepository.GetAll();
        }

        [HttpPost]
        public void Create([FromBody] Car car)
        {
            carRepository.Create(car);
        }

        [HttpPut]
        public void Update([FromBody] Car car)
        {
            carRepository.Update(car);
        }

        [HttpDelete]
        public void Delete([FromQuery] string number)
        {
            carRepository.Delete(number);
        }
    }
}
