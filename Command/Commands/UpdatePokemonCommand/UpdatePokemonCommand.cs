using Data.Interfaces;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification.Services;
using Domain.Pokemons;
using Resources.Shared;
using System.Net;

namespace Command.Commands.UpdatePokemonCommand
{
    public class UpdatePokemonCommand : DomainService, IUpdatePokemonCommand
    {
        private readonly IPokemonRepository _pokemonRepository;

        public UpdatePokemonCommand(
            IDomainNotificationHandlerAsync<DomainNotification> domainNotification,
            IPokemonRepository pokemonRepository) : base(domainNotification)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon> Execute(int id, Pokemon pokemon)
        {
            var pokemonEntity = await _pokemonRepository.FindAsync(id);

            if (pokemon is null)
            {
                await DomainNotification
                    .HandleAsync(new DomainNotification(HttpStatusCode.BadRequest, StringResources.PokemonBadRequest));
            }

            if (pokemonEntity is null)
            {
                await DomainNotification
                    .HandleAsync(new DomainNotification(HttpStatusCode.NotFound, StringResources.PokemonNotFound));
            }

            if (pokemon is not null)
            {
                await _pokemonRepository.Update(id, pokemon);
                await _pokemonRepository.SaveChanges();
            }

            return pokemon;
        }
    }
}
