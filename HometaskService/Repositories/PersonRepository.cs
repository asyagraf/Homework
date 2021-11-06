using HometaskService.Models;
using HometaskService.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<string> GetAll(Person person)
        {
            throw new NotImplementedException();
        }

        public string GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
