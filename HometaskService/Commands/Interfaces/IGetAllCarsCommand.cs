using HometaskService.Models;
using System.Collections.Generic;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetAllCarsCommand
    {
        List<Car> Execute();
    }
}
