using System.Net;

namespace Domain.DomainNotification
{
    public class DomainNotification
    {
        public HttpStatusCode StatusCode;
        public string Message;
        public string Key;
        public DateTime Timestamp { get; }

        public DomainNotification(HttpStatusCode statusCode, string message)
        {
            Timestamp = DateTime.Now;
            StatusCode = statusCode;
            Message = message;
        }
    }
}
