using SOLIDPrinciples.NotificationChannels;

namespace SOLIDPrinciples.Services
{
    public class CommunicationService
    {
        private readonly INotificationChannel _notificationChannel;

        public CommunicationService(INotificationChannel notificationChannel)
        {
            _notificationChannel = notificationChannel;
        }

        public void NotificateUser(User sender, User recipient, string notificationMessage, string date, string subject = "")
        {
            _notificationChannel.SendNotification(sender, recipient, notificationMessage, date, subject);
        }
    }

}
