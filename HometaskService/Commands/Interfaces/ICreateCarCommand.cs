using HometaskService.Models;

namespace HometaskService.Commands.Interfaces
{
    public interface ICreateCarCommand
    {
        void Execute(Car car);
    }
}
