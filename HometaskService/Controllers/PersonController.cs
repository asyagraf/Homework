using HometaskService.Models;
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
        private readonly string Path = @"C:\ServiceTest\Persons.txt";
        private string[] line = new string[4];

        [HttpGet("one")]
        public string Get([FromQuery] int id)
        {
            if (System.IO.File.Exists(Path))
            {
                try
                {
                    using StreamReader sr = new StreamReader(Path);
                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine().Split('/');
                        if (line[0] == id.ToString())
                        {
                            return $"Name: {line[1]}\nSurname: {line[2]}\nAge: {line[3]}";
                        }
                    }
                    return "There is no person with this ID";
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return "There is no file with persons";
        }

        [HttpGet("all")]
        public List<string> GetAll()
        {
            List<string> result = new List<string>();

            if (System.IO.File.Exists(Path))
            {
                try
                {
                    using StreamReader sr = new StreamReader(Path);
                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine().Split('/');
                        result.Add($"Name: {line[1]}   Surname: {line[2]}   Age: {line[3]}");
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return result;
        }

        [HttpPost]
        public void Create([FromBody] Person person)
        {
            if (!System.IO.File.Exists(Path))
            {
                System.IO.File.Create(Path).Close();
            }

            try
            {
                using StreamWriter sw = new StreamWriter(Path, true);
                sw.WriteLine($"{person.Id}/{person.Name}/{person.Surname}/{person.Age}");
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        [HttpPut]
        public void Update([FromBody] Person person)
        {
            List<string> persons = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (sr.Peek() != -1)
                    {
                        persons.Add(sr.ReadLine());
                    }
                }

                using StreamWriter sw = new StreamWriter(Path, false);
                foreach (string temp in persons)
                {
                    line = temp.Split('/');
                    if (line[0] != person.Id.ToString())
                    {
                        sw.WriteLine(temp);
                    }
                    else
                    {
                        sw.WriteLine($"{person.Id}/{person.Name}/{person.Surname}/{person.Age}");
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }

        }

        [HttpDelete]
        public void Delete([FromQuery] int id)
        {
            List<string> persons = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (sr.Peek() != -1)
                    {
                        persons.Add(sr.ReadLine());
                    }
                }

                using StreamWriter sw = new StreamWriter(Path, false);
                foreach (string temp in persons)
                {
                    line = temp.Split('/');
                    if (line[0] != id.ToString())
                    {
                        sw.WriteLine(temp);
                    }
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}
