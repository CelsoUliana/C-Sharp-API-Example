using Domain.PokemonBattle;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Interfaces
{
    public interface IPokemonBattleRepository
    {
        Task<PokemonBattle?> FindAsync(int id);
        Task<List<PokemonBattle>> GetAllAsync();
        ValueTask<EntityEntry<PokemonBattle>> Add(PokemonBattle pokemon);
        Task<int> SaveChanges();
    }
}
