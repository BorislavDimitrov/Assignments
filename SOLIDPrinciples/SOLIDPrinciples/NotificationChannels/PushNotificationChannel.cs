using SOLIDPrinciples.Notifications;

namespace SOLIDPrinciples.NotificationChannels
{
    public class PushNotificationChannel : NotificationChanelBase
    {
        public override void SendNotification(User sender, User recipient, string notificationMessage, string date, string subject = "")
        {
            base.SendNotification(sender, recipient, notificationMessage, date, subject);

            var newPushNotification = new PushNotification(sender, recipient, notificationMessage, DateTime.UtcNow.ToString());

            recipient.RecievelNotification(newPushNotification);

            Console.WriteLine("Sending push notification...");
            Console.WriteLine(newPushNotification.Info());
        }
    }
}
