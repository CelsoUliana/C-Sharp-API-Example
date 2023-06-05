namespace Domain.DomainNotification.Interfaces
{
    public interface IDomainNotificationHandlerAsync<T> where T : DomainNotification 
    {
        bool HasNotifications();
        List<T> GetNotifications();
        bool HasNotFound();
        bool HasBadRequest();
        Task HandleAsync(DomainNotification message);
        void Clean();
    }
}
