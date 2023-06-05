using Domain.PokemonBattle;

namespace Query.Queries.GetPokemonBattleList
{
    public interface IGetPokemonBattleListQuery
    {
        Task<List<PokemonBattle>> Execute();
    }
}
