using Domain.PokemonBattle;
using Domain.Pokemons;
using Microsoft.EntityFrameworkCore;

namespace Data.Interfaces
{
    public interface IPokemonBattleDbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        public DbSet<PokemonBattle> PokemonBattles { get; set; }

        Task<int> Save();
    }
}
