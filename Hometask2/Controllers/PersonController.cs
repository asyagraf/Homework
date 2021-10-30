using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hometask2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private string Path = @"c:\Persons.txt";
        private string TempPath = @"c:\PersonsTemp.txt";

        [HttpGet]
        //HDD
        public string Get([FromQuery] string name, [FromQuery] string surname, [FromQuery] int age)
        {
            return $"Name: {name} Surname: {surname} Age: {age}";
        }

        [HttpPost]
        public void Create([FromBody] Person person)
        {
            using StreamWriter sw = new StreamWriter(Path, true);
            sw.Write($"{person.Name} {person.Surname} {person.Age}");
        }

        [HttpPatch]
        public void Change()
        {

        }

        [HttpDelete]
        public void Delete([FromQuery] Person person)
        {
            using StreamWriter sw = new StreamWriter(TempPath);
            using StreamReader sr = new StreamReader(Path);

            string line;
            string del = $"{person.Name} {person.Surname} {person.Age}";

            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();
                if (line != del)
                {
                    sw.WriteLine(line);
                }
            }
            
            System.IO.File.Delete(Path);
            System.IO.File.Move(TempPath, Path);
        }
    }
}
