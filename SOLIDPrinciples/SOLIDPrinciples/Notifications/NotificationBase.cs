namespace SOLIDPrinciples.Notifications
{
    public abstract class NotificationBase : INotification
    {
        protected User _sender;
        protected User _recipient;
        protected string _notificationMessage;
        protected string _date;

        protected NotificationBase(User sender, User recipient, string notificationMesage, string date)
        {
            Sender = sender;
            Recipient = recipient;
            NotificationMessage = notificationMesage;
            Date = date;
        }

        public User Sender
        {
            init
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _sender = value;
            }
        }

        public User Recipient
        {
            init
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                _recipient = value;
            }
        }

        public string NotificationMessage
        {
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                _notificationMessage = value;
            }
        }

        public string Date
        {
            init
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException();
                }

                _date = value;
            }
        }

        public abstract string Info();

    }
}
