using HometaskService.Models;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetCarCommand
    {
        Car Execute(string number);
    }
}
