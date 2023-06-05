using Data.Interfaces;
using Domain.PokemonBattle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Repositories
{
    public class PokemonBattleRepository : IPokemonBattleRepository
    {
        private readonly PokemonBattleDbContext _context;

        public PokemonBattleRepository(PokemonBattleDbContext context)
        {
            _context = context;
        }

        public async ValueTask<EntityEntry<PokemonBattle>> Add(PokemonBattle battle)
        {
            return await _context.PokemonBattles.AddAsync(battle);
        }

        public async Task<PokemonBattle?> FindAsync(int id)
        {
            return await _context.PokemonBattles.FindAsync(id);
        }

        public async Task<List<PokemonBattle>> GetAllAsync()
        {
            return await _context.PokemonBattles
                .Include(x => x.Pokemon1)
                .Include(x => x.Pokemon2)
                .Include(x => x.WinnerPokemon)
                .ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.Save();
        }
    }
}
