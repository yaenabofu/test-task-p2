using api.Models.DatabaseObjects;
using api.Repositories.PaginationRepository;
using api.Repositories.PaginationRepository.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories.WorkerRepository
{
    public class WorkerRepository : IWorker
    {
        private readonly DatabaseContext _databaseContext;
        public WorkerRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public async Task<Worker> Create(Worker obj)
        {
            await _databaseContext.Workers.AddAsync(obj);
            await _databaseContext.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Worker obj = await _databaseContext.Workers.FindAsync(id);

            if (obj != null)
            {
                _databaseContext.Workers.Remove(obj);
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Worker>> GetAll()
        {
            return await _databaseContext.Workers.Include(c => c.Specialties).Include(c => c.WorkShifts).ToListAsync();
        }

        public async Task<Worker> Get(int id)
        {
            return await _databaseContext.Workers.Include(c => c.Specialties).Include(c => c.WorkShifts).FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<PagedList<Worker>> Get(PaginationParameters paginationParameters)
        {
            return Task.FromResult(PagedList<Worker>
                .ToPagedList(_databaseContext.Workers, paginationParameters.PageNumber, paginationParameters.PageSize));
        }

        public async Task<Worker> GetBySnils(string snils)
        {
            return await _databaseContext.Workers.Include(c => c.Specialties).Include(c => c.WorkShifts).FirstOrDefaultAsync(c => c.Snils == snils);
        }

        public async Task<Worker> Update(Worker оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
