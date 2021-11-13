using HometaskService.ModelsDTO;
using System.Threading.Tasks;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetBookCommand
    {
        Task<BookDTO> ExecuteAsync(int id);
    }
}
