using HometaskService.ModelsDTO;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetBookCommand
    {
        BookDTO Execute(int id);
    }
}
