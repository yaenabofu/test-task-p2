using api.Models.DatabaseObjects;
using System.Threading.Tasks;

namespace api.Repositories.WorkerRepository
{
    public interface IWorker : IRepository<Worker>
    {
        Task<Worker> GetBySnils(string snils);
    }
}
