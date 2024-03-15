using System.Text;

namespace SOLIDPrinciples.Notifications
{
    public class PushNotification : NotificationBase
    {
        public PushNotification(User sender, User recipient, string notificationMesage, string date) 
            : base(sender, recipient, notificationMesage, date)
        {
        }

        public override string Info()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Sender user name: {_sender.UserName}");
            sb.AppendLine($"Reciever user name: {_recipient.UserName}");
            sb.AppendLine($"Date: {_date}");
            sb.AppendLine($"Message: {_notificationMessage}");
            return sb.ToString();
        }
    }
}
