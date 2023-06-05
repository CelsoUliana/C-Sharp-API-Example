using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification.Services;
using Domain.PokemonBattle.Interfaces;
using Domain.Pokemons;
using Resources.Shared;
using System.Net;

namespace Domain.PokemonBattle.Services
{
    public class PokemonBattleService : DomainService, IPokemonBattleService
    {
        public PokemonBattleService(
            IDomainNotificationHandlerAsync<DomainNotification.DomainNotification> domainNotification) : base(domainNotification)
        {
        }

        public async Task<PokemonBattle?> Battle(Pokemon pokemon1, Pokemon pokemon2)
        {
            if (pokemon1 is null || pokemon2 is null)
            {
                await DomainNotification
                    .HandleAsync(new DomainNotification.DomainNotification(HttpStatusCode.BadRequest, StringResources.PokemonBadRequest));
                return null;
            }

            return await SimulateBattle(pokemon1, pokemon2);
        }

        private async Task<PokemonBattle> SimulateBattle(Pokemon pokemon1, Pokemon pokemon2)
        {
            var pokemon1Hp = pokemon1.HP;
            var pokemon2Hp = pokemon2.HP;

            while (pokemon1Hp > 0 && pokemon2Hp > 0)
            {
                bool pokemon1GoesFirst = Pokemon1GoesFirst(pokemon1, pokemon2);

                if (pokemon1GoesFirst)
                {
                    Attack(pokemon1, pokemon2, ref pokemon2Hp);

                    if (PokemonIsDefeated(pokemon2Hp))
                        break;

                    Attack(pokemon2, pokemon1, ref pokemon1Hp);
                }
                else
                {
                    Attack(pokemon2, pokemon1, ref pokemon1Hp);

                    if (PokemonIsDefeated(pokemon1Hp))
                        break;

                    Attack(pokemon1, pokemon2, ref pokemon2Hp);
                }
            }

            Pokemon winnerPokemon;

            if (PokemonIsDefeated(pokemon1Hp))
                winnerPokemon = pokemon2;
            else
                winnerPokemon = pokemon1;

            PokemonBattle battle = new PokemonBattle(pokemon1, pokemon2, winnerPokemon);

            return battle;
        }

        private static void Attack(Pokemon pokemon1, Pokemon pokemon2, ref int pokemon2Hp)
        {
            int damage;

            if (pokemon1.Attack <= pokemon2.Defense)
                damage = 1;
            else
                damage = pokemon1.Attack - pokemon2.Defense;

            decimal percentage = BattleHelper.CalculateTypePercentage(pokemon1, pokemon2);

            pokemon2Hp -= (int)(damage * percentage);
        }

        private static bool Pokemon1GoesFirst(Pokemon pokemon1, Pokemon pokemon2)
        {
            return pokemon1.Speed > pokemon2.Speed;
        }

        private static bool PokemonIsDefeated(int pokemonHp)
        {
            return pokemonHp <= 0;
        }
    }
}
