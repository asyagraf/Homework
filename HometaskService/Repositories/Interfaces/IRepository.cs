using System.Collections.Generic;

namespace HometaskService.Repositories.Interfaces
{
    public interface IRepository<T, K>
    {
        T Get(K id);
        List<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(K id);
    }
}
