using HometaskService.Models;

namespace HometaskService.Commands.Interfaces
{
    public interface ICreatePersonCommand
    {
        void Execute(Person person);
    }
}
