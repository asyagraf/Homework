using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        private readonly string Path = @"C:\ServiceTest\Persons.txt";
        private string[] line = new string[4];

        public void Create(Person person)
        {
            if (!File.Exists(Path))
            {
                File.Create(Path).Close();
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

        public void Delete(int id)
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

        public List<Person> GetAll()
        {
            List<Person> result = new List<Person>();

            if (File.Exists(Path))
            {
                try
                {
                    using StreamReader sr = new StreamReader(Path);
                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine().Split('/');
                        result.Add(new Person()
                        {
                            Id = int.Parse(line[0]),
                            Name = line[1],
                            Surname = line[2],
                            Age = int.Parse(line[3])
                        });
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return result;
        }

        public Person GetById(int id)
        {
            Person person = null;
            if (File.Exists(Path))
            {
                try
                {
                    using StreamReader sr = new StreamReader(Path);
                    while (sr.Peek() != -1)
                    {
                        line = sr.ReadLine().Split('/');
                        if (line[0] == id.ToString())
                        {
                            person = new Person()
                            {
                                Id = int.Parse(line[0]),
                                Name = line[1],
                                Surname = line[2],
                                Age = int.Parse(line[3])
                            };
                        }
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc.Message);
                }
            }
            return person;
        }

        public void Update(Person person)
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
    }
}
