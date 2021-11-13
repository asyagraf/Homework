using HometaskService.DBModels;
using System.Threading.Tasks;

namespace HometaskService.Commands.Interfaces
{
    public interface IUpdateBookCommand
    {
        Task ExecuteAsync(DBBook book);
    }
}
