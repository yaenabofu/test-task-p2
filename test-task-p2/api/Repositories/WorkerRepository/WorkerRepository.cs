using api.Models.DatabaseObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Worker>> Get()
        {
            return await _databaseContext.Workers.ToListAsync();
        }

        public async Task<Worker> Get(int id)
        {
            return await _databaseContext.Workers.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Worker> GetBySnils(string snils)
        {
            return await _databaseContext.Workers.FirstOrDefaultAsync(c => c.Snils == snils);
        }

        public async Task<Worker> Update(Worker оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
