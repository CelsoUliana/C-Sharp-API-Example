using Domain.DomainNotification.Interfaces;

namespace Domain.DomainNotification.Services
{
    public abstract class DomainService
    {
        protected readonly IDomainNotificationHandlerAsync<DomainNotification> DomainNotification;

        protected DomainService(IDomainNotificationHandlerAsync<DomainNotification> domainNotification)
        {
            DomainNotification = domainNotification;
        }
    }
}
