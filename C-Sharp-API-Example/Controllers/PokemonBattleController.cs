using Command.Commands.CreatePokemonBattleCommand;
using Domain.DomainNotification;
using Domain.DomainNotification.Interfaces;
using Domain.PokemonBattle;
using Microsoft.AspNetCore.Mvc;
using Query.Queries.GetPokemonBattleList;

namespace C_Sharp_API_Example.Controllers
{
    public class PokemonBattleController : BaseApiController
    {
        public PokemonBattleController(
            IDomainNotificationHandlerAsync<DomainNotification> domainNotifications) : base(domainNotifications)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IGetPokemonBattleListQuery getPokemonBattleListQuery)
        {
            return ReturnDefault(await getPokemonBattleListQuery.Execute());
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromServices] ICreatePokemonBattleCommand createPokemonBattleCommand, [FromBody] PokemonBattle battle)
        {
            var battleEntity = await createPokemonBattleCommand.Execute(battle);

            return ReturnDefault(battleEntity);
        }
    }
}
