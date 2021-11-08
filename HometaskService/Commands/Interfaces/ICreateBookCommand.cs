using HometaskService.ModelsDTO;

namespace HometaskService.Commands.Interfaces
{
    public interface ICreateBookCommand
    {
        void Execute(BookDTO book);
    }
}
