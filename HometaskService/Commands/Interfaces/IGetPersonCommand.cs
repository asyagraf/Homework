using HometaskService.Models;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetPersonCommand
    {
        Person Execute(int id);
    }
}
