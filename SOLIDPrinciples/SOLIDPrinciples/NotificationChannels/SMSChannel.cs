using SOLIDPrinciples.Notifications;

namespace SOLIDPrinciples.NotificationChannels
{
    public class SMSChannel : NotificationChanelBase
    {
        public override void SendNotification(User sender, User recipient, string notificationMessage, string date, string subject = "")
        {
            base.SendNotification(sender, recipient, notificationMessage, date, subject);

            var newSMSNotification = new SMSNotification(sender, recipient, notificationMessage, DateTime.UtcNow.ToString());

            recipient.RecievelNotification(newSMSNotification);

            Console.WriteLine("Sending SMS notification...");
            Console.WriteLine(newSMSNotification.Info());
        }
    }
}
