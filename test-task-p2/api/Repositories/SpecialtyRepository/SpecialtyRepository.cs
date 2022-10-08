using api.Models.DatabaseObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories.SpecialtyRepository
{
    public class SpecialtyRepository : IRepository<Specialty>
    {
        private readonly DatabaseContext _databaseContext;
        public SpecialtyRepository(DatabaseContext databaseContext)
        {
            this._databaseContext = databaseContext;
        }
        public async Task<Specialty> Create(Specialty obj)
        {
            await _databaseContext.Specialties.AddAsync(obj);
            await _databaseContext.SaveChangesAsync();

            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            Specialty obj = await _databaseContext.Specialties.FindAsync(id);

            if (obj != null)
            {
                _databaseContext.Specialties.Remove(obj);
                await _databaseContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<IEnumerable<Specialty>> Get()
        {
            return await _databaseContext.Specialties.ToListAsync();
        }

        public async Task<Specialty> Get(int id)
        {
            return await _databaseContext.Specialties.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Specialty> Update(Specialty оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
