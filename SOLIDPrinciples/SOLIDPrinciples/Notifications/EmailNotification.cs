using System.Text;

namespace SOLIDPrinciples.Notifications
{
    public class EmailNotification : NotificationBase
    {
        private string _subject;

        public EmailNotification(User sender, User recipient, string notificationMesage, string date, string subject)
            : base(sender, recipient, notificationMesage, date)
        {
            Subject = subject;
        }

        public string Subject
        {
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                _subject = value;
            }
        }

        public override string Info()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"From: {_sender.Email}");
            sb.AppendLine($"To {_recipient.Email}");
            sb.AppendLine($"Date: {_date}");
            sb.AppendLine($"Subject: {_subject}");
            sb.AppendLine($"Message content: {_notificationMessage}");

            return sb.ToString();
        }
    }
}
