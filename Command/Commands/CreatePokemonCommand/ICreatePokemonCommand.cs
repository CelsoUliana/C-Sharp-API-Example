using Domain.Pokemons;

namespace Command.Commands.CreatePokemonCommand
{
    public interface ICreatePokemonCommand
    {
        Task<Pokemon> Execute(Pokemon pokemon);
    }
}
