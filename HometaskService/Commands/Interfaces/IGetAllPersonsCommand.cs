using System.Collections.Generic;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetAllPersonsCommand
    {
        List<string> Execute();
    }
}
