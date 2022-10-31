using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _appDbContext;

        public ActorsService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public async Task AddAsync(Actor actor)
        {
            await _appDbContext.AddAsync(actor);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(x => x.Id == id);
            _appDbContext.Actors.Remove(result);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _appDbContext.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _appDbContext.Actors.FirstOrDefaultAsync(act => act.Id == id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _appDbContext.Actors.Update(newActor);
            await _appDbContext.SaveChangesAsync();
            return newActor;
        }
    }
}
