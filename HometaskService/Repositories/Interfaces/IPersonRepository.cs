using HometaskService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        Person GetById(int id);
        List<Person> GetAll();
        void Create(Person person);
        void Update(Person person);
        void Delete(int id);

    }
}
