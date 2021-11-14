using HometaskService.ModelsDTO;
using System.Threading.Tasks;

namespace HometaskService.Commands.Interfaces
{
    public interface ICreateBookCommand
    {
        Task ExecuteAsync(BookDTO book);
    }
}
