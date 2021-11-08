using HometaskService.DBModels;
using HometaskService.ModelsDTO;
using System.Collections.Generic;

namespace HometaskService.Repositories.Interfaces
{
    public interface IBookRepository
    {
        DBBook Get(int id);
        List<DBBook> GetAll();
        void Create(BookDTO item);
        void Update(DBBook item);
        void Delete(int id);
    }
}
