using HometaskService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Repositories.Interfaces
{
    public interface ICarRepository
    {
        string GetByNumber(string number);
        List<string> GetAll();
        void Create(Car car);
        void Update(Car car);
        void Delete(string number);

    }
}
