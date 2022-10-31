using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _appDbContext;

        public EntityBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public async Task AddAsync(T item) => await _appDbContext.Set<T>().AddAsync(item);

        public async Task DeleteAsync(int id)
        {
            var entity = await _appDbContext.Set<T>().FirstOrDefaultAsync(act => act.Id == id);
            EntityEntry entityEntry = _appDbContext.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
        }

        public async Task<IEnumerable<T>> GetAllAsync() =>  await _appDbContext.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id) => await _appDbContext.Set<T>().FirstOrDefaultAsync(act => act.Id == id);


        public async Task UpdateAsync(int id, T newItem)
        {
            EntityEntry entityEntry = _appDbContext.Entry<T>(newItem);
            entityEntry.State = EntityState.Modified;
        }
    }
}
