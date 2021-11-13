using HometaskService.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HometaskService.Commands.Interfaces
{
    public interface IGetAllBooksCommand
    {
        Task<List<BookDTO>> ExecuteAsync();
    }
}
