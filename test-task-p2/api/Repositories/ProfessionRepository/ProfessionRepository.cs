using api.Models.DatabaseObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories.ProfessionRepository
{
    public class ProfessionRepository : IRepository<Profession>
    {
        private readonly DatabaseContext _databaseContext;
        public ProfessionRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public async Task<Profession> Create(Profession obj)
        {
            await _databaseContext.Professions.AddAsync(obj);
            await _databaseContext.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Profession obj = await _databaseContext.Professions.FindAsync(id);

            if (obj != null)
            {
                _databaseContext.Professions.Remove(obj);
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Profession>> Get()
        {
            return await _databaseContext.Professions.Include(c => c.Specialties).ToListAsync();
        }

        public async Task<Profession> Get(int id)
        {
            return await _databaseContext.Professions.Include(c => c.Specialties).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Profession> Update(Profession оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
