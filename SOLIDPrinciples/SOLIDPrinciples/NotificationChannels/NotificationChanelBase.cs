namespace SOLIDPrinciples.NotificationChannels
{
    public abstract class NotificationChanelBase : INotificationChannel
    {
        public virtual void SendNotification(User sender, User recipient, string notificationMessage, string date, string subject = "")
        {
            if (sender == null || recipient == null || string.IsNullOrEmpty(notificationMessage))
            {
                throw new ArgumentNullException();
            }
        }
    }
}
