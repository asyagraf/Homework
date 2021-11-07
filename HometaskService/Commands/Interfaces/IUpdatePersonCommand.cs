using HometaskService.Models;

namespace HometaskService.Commands.Interfaces
{
    public interface IUpdatePersonCommand
    {
        void Execute(Person person);
    }
}
