using System;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetPersonCommand
    {
        string Execute(int id);
    }
}
