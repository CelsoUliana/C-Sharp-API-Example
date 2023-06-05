using Data.Interfaces;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification.Services;
using Domain.Pokemons;
using Resources.Shared;
using System.Net;

namespace Command.Commands.CreatePokemonCommand
{
    public class CreatePokemonCommand : DomainService, ICreatePokemonCommand
    {
        private readonly IPokemonRepository _pokemonRepository;

        public CreatePokemonCommand(
            IDomainNotificationHandlerAsync<DomainNotification> domainNotification,
            IPokemonRepository pokemonRepository) : base(domainNotification)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon> Execute(Pokemon pokemon)
        {
            var id = 0;

            if (pokemon is not null) {
                await _pokemonRepository.Add(pokemon);
                id = await _pokemonRepository.SaveChanges();
            }

            else if (pokemon is null || id < 0)
            {
                await DomainNotification.HandleAsync(new DomainNotification(HttpStatusCode.BadRequest, StringResources.PokemonBadRequest));
            }

            return pokemon;
        }
    }
}
