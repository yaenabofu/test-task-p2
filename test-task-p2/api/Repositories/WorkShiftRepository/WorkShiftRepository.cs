using api.Models.DatabaseObjects;
using api.Repositories.PaginationRepository;
using api.Repositories.PaginationRepository.Parameters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories.WorkShiftRepository
{
    public class WorkShiftRepository : IRepository<WorkShift>
    {
        private readonly DatabaseContext _databaseContext;
        public WorkShiftRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public async Task<WorkShift> Create(WorkShift obj)
        {
            await _databaseContext.WorkShifts.AddAsync(obj);
            await _databaseContext.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            WorkShift obj = await _databaseContext.WorkShifts.FindAsync(id);

            if (obj != null)
            {
                _databaseContext.WorkShifts.Remove(obj);
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<WorkShift>> GetAll()
        {
            return await _databaseContext.WorkShifts.ToListAsync();
        }

        public async Task<WorkShift> Get(int id)
        {
            return await _databaseContext.WorkShifts.FirstOrDefaultAsync(c => c.Id == id);
        }
        public Task<PagedList<WorkShift>> Get(PaginationParameters paginationParameters)
        {
            return Task.FromResult(PagedList<WorkShift>
                .ToPagedList(_databaseContext.WorkShifts, paginationParameters.PageNumber, paginationParameters.PageSize));
        }
        public async Task<WorkShift> Update(WorkShift оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
