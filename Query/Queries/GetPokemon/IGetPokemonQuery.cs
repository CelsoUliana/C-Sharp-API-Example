using Domain.Pokemons;

namespace Query.Queries.GetPokemon
{
    public interface IGetPokemonQuery
    {
        Task<Pokemon> Execute(int id);
    }
}