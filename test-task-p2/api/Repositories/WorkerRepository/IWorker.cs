namespace api.Repositories.WorkerRepository
{
    public interface IWorker : IRepository<Worker>
    {
        Task<Worker> GetBySnils(string snils);
    }
}
