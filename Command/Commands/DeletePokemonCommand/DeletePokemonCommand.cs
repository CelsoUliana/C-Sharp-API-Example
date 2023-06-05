using Data.Interfaces;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification.Services;
using Resources.Shared;
using System.Net;

namespace Command.Commands.DeletePokemonCommand
{
    public class DeletePokemonCommand : DomainService, IDeletePokemonCommand
    {
        private readonly IPokemonRepository _pokemonRepository;

        public DeletePokemonCommand(
            IDomainNotificationHandlerAsync<DomainNotification> domainNotification, 
            IPokemonRepository pokemonRepository) : base(domainNotification)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task Execute(int id)
        {
            var pokemon = await _pokemonRepository.FindAsync(id);

            if (pokemon is null)
            {
                await DomainNotification
                    .HandleAsync(new DomainNotification(HttpStatusCode.NotFound, StringResources.PokemonNotFound));
                return;
            }

            await _pokemonRepository.Delete(id);
            await _pokemonRepository.SaveChanges();
        }
    }
}
