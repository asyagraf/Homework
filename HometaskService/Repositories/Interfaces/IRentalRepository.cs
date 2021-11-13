using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HometaskService.Repositories.Interfaces
{
    public interface IRentalRepository<T>
    {
        Task Create(T item);
        Task Delete(int id);
        Task Update(T item);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}
