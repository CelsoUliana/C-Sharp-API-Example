using Data.Interfaces;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification.Services;
using Domain.PokemonBattle;
using Domain.PokemonBattle.Interfaces;

namespace Command.Commands.CreatePokemonBattleCommand
{
    public class CreatePokemonBattleCommand : DomainService, ICreatePokemonBattleCommand
    {
        private readonly IPokemonBattleRepository _pokemonBattleRepository;
        private readonly IPokemonBattleService _pokemonBattleService;
        private readonly IPokemonRepository _pokemonRepository;

        public CreatePokemonBattleCommand(
            IDomainNotificationHandlerAsync<DomainNotification> domainNotification,
            IPokemonBattleRepository pokemonBattleRepository,
            IPokemonBattleService pokemonBattleService,
            IPokemonRepository pokemonRepository) : base(domainNotification)
        {
            _pokemonBattleRepository = pokemonBattleRepository;
            _pokemonBattleService = pokemonBattleService;
            _pokemonRepository = pokemonRepository;
        }

        public async Task<PokemonBattle> Execute(PokemonBattle battle)
        {

            var pokemon1 = await _pokemonRepository.FindAsync(battle.Pokemon1Id);
            var pokemon2 = await _pokemonRepository.FindAsync(battle.Pokemon2Id);

            var battleEntity = await _pokemonBattleService.Battle(pokemon1, pokemon2);

            if (battleEntity is not null)
            {
                await _pokemonBattleRepository.Add(battleEntity);
                await _pokemonBattleRepository.SaveChanges();
            }

            return battleEntity;
        }
    }
}
