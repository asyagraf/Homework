using HometaskService.Models;
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
        //fix keys and _cache
        private IMemoryCache _cache;
        private List<string> _keys;

        public CarController(IMemoryCache cache, List<string> keys)
        {
            _cache = cache;
            _keys = keys;
        }

        [HttpGet("one")]
        public string Get([FromQuery] string number)
        {
            if (_cache.Get(number) is not null)
            {
                try
                {
                    Car car = (Car)_cache.Get(number);
                    return $"Brand: {car.Brand}\nModel: {car.Model}\nNumber: {number}";
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return "This car doesn't exist";

        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            List<string> cars = new List<string>();
            foreach (string key in _keys)
            {
                try
                {
                    Car car = (Car)_cache.Get(key);
                    cars.Add($"Brand: {car.Brand}   Model: {car.Model}   Number: {car.Number}");
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return cars;
        }

        [HttpPost]
        public void Create([FromBody] Car car)
        {
            if (_cache.Get(car.Number) is null)
            {
                _cache.Set(car.Number, car);
                _keys.Add(car.Number);
            }
        }

        [HttpPut]
        public void Update([FromQuery] string number, [FromBody] Car car)
        {
            if (_cache.Get(number) is not null)
            {
                _cache.Set(car.Number, car);
                _keys.Remove(number);
                _keys.Add(car.Number);
            }
        }

        [HttpDelete]
        public void Delete([FromQuery] string number)
        {
            if (_cache.Get(number) is not null)
            {
                _cache.Remove(number);
                _keys.Remove(number);
            }
        }
    }
}
