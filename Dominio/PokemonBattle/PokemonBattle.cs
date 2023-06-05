using Domain.Base;
using Domain.Pokemons;

namespace Domain.PokemonBattle
{
    public class PokemonBattle : IEntity
    {
        public int Id { get; set; }

        public int? Pokemon1Id { get; set; }
        public int? Pokemon2Id { get; set; }
        public int? PokemonWinnerId { get; set; }

        public virtual Pokemon? Pokemon1 { get; set; }
        public virtual Pokemon? Pokemon2 { get; set; }
        public virtual Pokemon? WinnerPokemon { get; set; }

        public PokemonBattle() { }

        public PokemonBattle(Pokemon pokemon1, Pokemon pokemon2, Pokemon winner)
        {
            Pokemon1 = pokemon1;
            Pokemon2 = pokemon2;
            WinnerPokemon = winner;
        }
    }
}
