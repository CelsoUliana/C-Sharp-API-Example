using Domain.Pokemons;

namespace Domain.PokemonBattle.Interfaces
{
    public interface IPokemonBattleService
    {
        Task<PokemonBattle?> Battle(Pokemon pokemon1, Pokemon pokemon2);
    }
}
