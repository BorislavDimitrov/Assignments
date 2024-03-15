using System.Text;

namespace SOLIDPrinciples.Notifications
{
    public class SMSNotification : NotificationBase
    {
        public SMSNotification(User sender, User recipient, string notificationMesage, string date) 
            : base(sender, recipient, notificationMesage, date)
        {
            
        }

        public override string Info()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Sender phone number: {_sender.PhoneNumber}");
            sb.AppendLine($"Reciever phone number: {_recipient.PhoneNumber}");
            sb.AppendLine($"Date: {_date}");
            sb.AppendLine($"Message: {_notificationMessage}");
            return sb.ToString();
        }
    }
}
