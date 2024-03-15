using SOLIDPrinciples.Notifications;

namespace SOLIDPrinciples
{
    public class User
    {
        private string _userName;
        private string _phoneNumber;
        private string _email;
        private readonly List<EmailNotification> _receivedEmailNotifications;
        private readonly List<SMSNotification> _receivedSMSNotifications;
        private readonly List<PushNotification> _recievedPushNotifications;

        public User(string userName, string phoneNumber, string email)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
            Email = email;
            _receivedEmailNotifications = new List<EmailNotification>();
            _receivedSMSNotifications = new List<SMSNotification>();
            _recievedPushNotifications = new List<PushNotification>();
        }

        public string UserName
        {
            get => _userName;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _userName = value;
            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _phoneNumber = value;
            }
        }

        public string Email
        {
            get => _email;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _email = value;
            }
        }

        public List<EmailNotification> ReceivedEmailNotifications => _receivedEmailNotifications;

        public List<SMSNotification> ReceivedSMSNotifications => _receivedSMSNotifications;

        public List<PushNotification> ReceivedPushNotifications => _recievedPushNotifications;

        public void RecievelNotification(INotification notification)
        {
            if (notification == typeof(EmailNotification))
            {
                _receivedEmailNotifications.Add((EmailNotification) notification);
            } 
            else if (notification == typeof(SMSNotification))
            {
                _receivedSMSNotifications.Add((SMSNotification) notification);
            }
            else if (notification == typeof(PushNotification))
            {
                _recievedPushNotifications.Add((PushNotification)notification);
            }
        }
    }
}
