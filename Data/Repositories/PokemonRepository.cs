using Data.Interfaces;
using Domain.Pokemons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly PokemonBattleDbContext _context;

        public PokemonRepository(PokemonBattleDbContext context)
        {
            _context = context;
        }

        public async Task Update(int id, Pokemon pokemon)
        {
            Pokemon entity = await _context.Pokemons.FindAsync(id);

            if (entity is not null)
            {
                _context.Entry<Pokemon>(entity).CurrentValues.SetValues(pokemon);
            }
        }

        public async Task<Pokemon?> FindAsync(int? id)
        {
            return await _context.Pokemons.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Pokemon>> GetAllAsync()
        {
            return await _context.Pokemons.ToListAsync();
        }

        public async ValueTask<EntityEntry<Pokemon>> Add(Pokemon pokemon) 
        {
            return await _context.Pokemons.AddAsync(pokemon);
        }

        public async Task<EntityEntry<Pokemon>?> Delete(int id)
        {
            Pokemon? entity = await this._context.Set<Pokemon>().FindAsync(id);
            return entity == null ? null : this._context.Set<Pokemon>().Remove(entity);
        }

        public async Task<int> SaveChanges()
        {
            return await _context.Save();
        }
    }
}
