using HometaskService.DBModels;

namespace HometaskService.Commands.Interfaces
{
    public interface IUpdateBookCommand
    {
        void Execute(DBBook book);
    }
}
