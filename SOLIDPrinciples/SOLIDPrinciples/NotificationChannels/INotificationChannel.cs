namespace SOLIDPrinciples.NotificationChannels
{
    public interface INotificationChannel
    {
        void SendNotification(User sender, User recipient, string notificationMessage, string date, string subject = "");
    }
}
