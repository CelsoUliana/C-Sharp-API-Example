using Domain.PokemonBattle;

namespace Command.Commands.CreatePokemonBattleCommand
{
    public interface ICreatePokemonBattleCommand
    {
        Task<PokemonBattle> Execute(PokemonBattle battle);
    }
}
