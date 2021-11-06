using HometaskService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Repositories.Interfaces
{
    internal interface IPersonRepository
    {
        string GetById(int id);
        List<string> GetAll();
        void Create(Person person);
        void Update(Person person);
        void Delete(int id);

    }
}
