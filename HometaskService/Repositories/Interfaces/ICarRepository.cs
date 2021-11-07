using HometaskService.Models;
using System.Collections.Generic;

namespace HometaskService.Repositories.Interfaces
{
    public interface ICarRepository
    {
        Car GetByNumber(string number);
        List<Car> GetAll();
        void Create(Car car);
        void Update(Car car);
        void Delete(string number);

    }
}
