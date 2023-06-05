using Domain.Pokemons;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data.Interfaces
{
    public interface IPokemonRepository
    {
        Task Update(int id, Pokemon pokemon);
        Task<Pokemon?> FindAsync(int? id);
        Task<List<Pokemon>> GetAllAsync();
        ValueTask<EntityEntry<Pokemon>> Add(Pokemon pokemon);
        Task<int> SaveChanges();
        Task<EntityEntry<Pokemon>?> Delete(int id);
    }
}
