using CarRentalService.Request;
using MassTransit.Clients;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        public ClientController()
        {

        }
        [HttpGet("one")]
        public void Get()
        {
        }

        [HttpGet("all")]
        public void GetAll()
        {
        }

        [HttpPost]
        public void Create()
        {
        }

        [HttpDelete]
        public void Delete()
        {
        }

        [HttpPut]
        public void Update()
        {
        }
    }
}
