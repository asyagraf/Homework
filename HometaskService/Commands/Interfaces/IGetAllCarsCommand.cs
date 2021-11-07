using HometaskService.ModelsDTO;
using System.Collections.Generic;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetAllCarsCommand
    {
        List<CarDTO> Execute();
    }
}
