using Domain.Base;

namespace Domain.Pokemons
{
    public class Pokemon : IEntity
    {
        public int Id { get; set; }

        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Speed { get; set; }
        public int HP { get; set; }
        public string Name { get; set; }
        public PokemonType Type1 { get; set; }
        public PokemonType? Type2 { get; set; }  
    }
}
