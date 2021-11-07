using HometaskService.Models;

namespace HometaskService.Commands.Interfaces
{
    public interface IUpdateCarCommand
    {
        void Execute(Car car);
    }
}
