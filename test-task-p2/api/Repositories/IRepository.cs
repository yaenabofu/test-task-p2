using api.Repositories.PaginationRepository;
using api.Repositories.PaginationRepository.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
    public interface IRepository<T>
    {
        Task<PagedList<T>> Get(PaginationParameters paginationParameters);
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Create(T obj);
        Task<T> Update(T оbj);
        Task<bool> Delete(int id);
    }
}
