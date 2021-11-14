using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HometaskService.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<DBBook> Get(int id);
        Task<List<DBBook>> GetAll();
        Task Create(BookDTO item);
        Task Update(DBBook item);
        Task Delete(int id);
    }
}
