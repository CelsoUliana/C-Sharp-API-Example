using Domain.Pokemons;

namespace Command.Commands.UpdatePokemonCommand
{
    public interface IUpdatePokemonCommand
    {
        Task<Pokemon> Execute(int id, Pokemon pokemon);
    }
}
