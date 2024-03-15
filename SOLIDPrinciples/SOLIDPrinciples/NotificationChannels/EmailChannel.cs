using SOLIDPrinciples.Notifications;

namespace SOLIDPrinciples.NotificationChannels
{
    public class EmailChannel : NotificationChanelBase
    {
        public override void SendNotification(User sender, User recipient, string notificationMessage, string date, string subject = "")
        {
            base.SendNotification(sender, recipient, notificationMessage, subject);

            if (string.IsNullOrEmpty(subject))
            {
                throw new ArgumentNullException();
            }

            var newEmailNotification = new EmailNotification(sender, recipient, notificationMessage, DateTime.UtcNow.ToString(), subject);

            recipient.RecievelNotification(newEmailNotification);

            Console.WriteLine("Sending email notification...");
            Console.WriteLine(newEmailNotification.Info());
        }
    }
}
