using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hometask2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        [HttpGet]
        //MemoryCashe
        public string Get([FromQuery] string brand, [FromQuery] string model, [FromQuery] string number)
        {
            return $"Brand: {brand} Model: {model} Number: {number}";
        }

        [HttpPost]
        public void Create([FromBody] Car car)
        {

        }

        [HttpPatch]
        public void Change()
        {

        }

        [HttpDelete]
        public void Delete()
        {

        }
    }
}
