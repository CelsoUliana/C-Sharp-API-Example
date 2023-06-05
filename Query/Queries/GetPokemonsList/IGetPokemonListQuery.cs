using Domain.Pokemons;

namespace Query.Queries.GetPokemonsList
{
    public interface IGetPokemonListQuery
    {
        Task<List<Pokemon>> Execute();
    }
}
