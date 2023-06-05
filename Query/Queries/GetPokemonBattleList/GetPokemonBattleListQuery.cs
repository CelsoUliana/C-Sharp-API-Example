using Data.Interfaces;
using Domain.PokemonBattle;

namespace Query.Queries.GetPokemonBattleList
{
    public class GetPokemonBattleListQuery : IGetPokemonBattleListQuery
    {
        private readonly IPokemonBattleRepository _pokemonBattleRepository;

        public GetPokemonBattleListQuery(IPokemonBattleRepository pokemonBattleRepository)
        {
            _pokemonBattleRepository = pokemonBattleRepository;
        }

        public async Task<List<PokemonBattle>> Execute()
        {
            return await _pokemonBattleRepository.GetAllAsync();
        }
    }
}
