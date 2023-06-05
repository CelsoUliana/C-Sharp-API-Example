using Domain.DomainNotification.Interfaces;
using System.Net;

namespace Domain.DomainNotification.Handlers
{
    public class DomainNotificationHandlerAsync :
        IDomainNotificationHandlerAsync<DomainNotification>
    {
        private List<DomainNotification> _notifications;

        public DomainNotificationHandlerAsync()
        {
            _notifications = new List<DomainNotification>();
        }

        public Task HandleAsync(DomainNotification message)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public bool HasNotFound()
        {
            return GetNotifications()
                .Any(p => p.StatusCode == HttpStatusCode.NotFound);
        }

        public bool HasBadRequest()
        {
            return GetNotifications()
                .Any(p => p.StatusCode == HttpStatusCode.BadRequest);
        }

        public List<DomainNotification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return GetNotifications()
                .Any();
        }

        public void Clean()
        {
            _notifications = new List<DomainNotification>();
        }

        public void Dispose()
        {
            Clean();
        }
    }
}
