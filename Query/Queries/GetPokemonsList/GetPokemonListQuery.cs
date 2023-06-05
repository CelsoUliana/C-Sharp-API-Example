using Data.Interfaces;
using Domain.Pokemons;

namespace Query.Queries.GetPokemonsList
{
    public class GetPokemonListQuery : IGetPokemonListQuery
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetPokemonListQuery(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<List<Pokemon>> Execute()
        {
            return await _pokemonRepository.GetAllAsync();
        }
    }
}
