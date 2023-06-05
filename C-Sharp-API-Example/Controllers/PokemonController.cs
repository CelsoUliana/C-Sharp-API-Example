using Command.Commands.CreatePokemonCommand;
using Command.Commands.DeletePokemonCommand;
using Command.Commands.UpdatePokemonCommand;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.Pokemons;
using Microsoft.AspNetCore.Mvc;
using Query.Queries.GetPokemon;
using Query.Queries.GetPokemonsList;

namespace C_Sharp_API_Example.Controllers
{
    public class PokemonController : BaseApiController
    {
        public PokemonController(
            IDomainNotificationHandlerAsync<DomainNotification> domainNotifications) : base(domainNotifications)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromServices] IGetPokemonListQuery getPokemonListQuery)
        {
            return Ok(await getPokemonListQuery.Execute());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Find([FromServices] IGetPokemonQuery getPokemonQuery, int id)
        {
            var pokemon = await getPokemonQuery.Execute(id);

            return ReturnDefault(pokemon);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ICreatePokemonCommand createPokemonCommand, [FromBody] Pokemon pokemon)
        {
            var pokemonEntity = await createPokemonCommand.Execute(pokemon);

            return ReturnDefault(pokemonEntity);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromServices] IUpdatePokemonCommand updatePokemonCommand, int id, [FromBody] Pokemon pokemon)
        {
            var pokemonEntity = await updatePokemonCommand.Execute(id, pokemon);

            return ReturnDefault(pokemonEntity);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromServices] IDeletePokemonCommand deletePokemonCommand, int id)
        {
            await deletePokemonCommand.Execute(id);

            return ReturnDefault(string.Empty);
        }
    }
}
