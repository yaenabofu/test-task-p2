using api.Models.DatabaseObjects;
using api.Repositories.PaginationRepository;
using api.Repositories.PaginationRepository.Parameters;
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

        public async Task<IEnumerable<Specialty>> GetAll()
        {
            return await _databaseContext.Specialties.ToListAsync();
        }

        public async Task<Specialty> Get(int id)
        {
            return await _databaseContext.Specialties.FirstOrDefaultAsync(c => c.Id == id);
        }

        public Task<PagedList<Specialty>> Get(PaginationParameters paginationParameters)
        {
            return Task.FromResult(PagedList<Specialty>
                .ToPagedList(_databaseContext.Specialties, paginationParameters.PageNumber, paginationParameters.PageSize));
        }

        public async Task<Specialty> Update(Specialty оbj)
        {
            _databaseContext.Entry(оbj).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();
            return оbj;
        }
    }
}
