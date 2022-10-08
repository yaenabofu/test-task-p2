using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(int id);
        Task<T> Create(T obj);
        Task<T> Update(T оbj);
        Task<bool> Delete(int id);
    }
}
