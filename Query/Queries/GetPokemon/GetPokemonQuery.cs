using Data.Interfaces;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification.Services;
using Domain.Pokemons;
using Resources.Shared;
using System.Net;

namespace Query.Queries.GetPokemon
{
    public class GetPokemonQuery : DomainService, IGetPokemonQuery
    {
        private readonly IPokemonRepository _pokemonRepository;

        public GetPokemonQuery(
            IPokemonRepository pokemonRepository, 
            IDomainNotificationHandlerAsync<DomainNotification> domainNotificationHandlerAsync) : base(domainNotificationHandlerAsync)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task<Pokemon> Execute(int id)
        {
            var pokemon = await _pokemonRepository.FindAsync(id);

            if (pokemon is null)
            {
                await DomainNotification
                    .HandleAsync(new DomainNotification(HttpStatusCode.NotFound, StringResources.PokemonNotFound));
            }

            return pokemon;
        }
    }
}
