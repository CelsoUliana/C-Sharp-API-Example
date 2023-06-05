using Domain.Pokemons;

namespace Domain.PokemonBattle
{
    public static class BattleHelper
    {
        public static decimal CalculateTypePercentage(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1.Type1 == PokemonType.Fire && pokemon2.Type1 == PokemonType.Grass)
                return 2;

            if (pokemon1.Type1 == PokemonType.Fire && pokemon2.Type1 == PokemonType.Water)
                return 0.5M;

            // FutherTypings calculating...
            // Type could futher be put in classes and have an array of types called win, loses, negates
            // TODO

            return 1;
        }
    }
}
