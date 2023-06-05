using Domain.DomainNotification.Interfaces;
using Domain.DomainNotification;
using Microsoft.AspNetCore.Mvc;

namespace C_Sharp_API_Example.Controllers
{
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        protected readonly IDomainNotificationHandlerAsync<DomainNotification> DomainNotifications;

        public BaseApiController(IDomainNotificationHandlerAsync<DomainNotification> domainNotifications)
        {
            DomainNotifications = domainNotifications;
        }

        protected bool ValidOperation() => !DomainNotifications.HasNotifications();

        protected IActionResult ReturnDefault(object defaultReturn)
        {
            if (!ValidOperation())
            {
                var messages = DomainNotifications.GetNotifications().Select(n => n.Message);

                if (DomainNotifications.HasNotFound())
                    return NotFound(messages);

                if (DomainNotifications.HasBadRequest())
                    return BadRequest(messages); 
            }

            return Ok(defaultReturn);
        }
    }
}
