using SOLIDPrinciples;
using SOLIDPrinciples.NotificationChannels;
using SOLIDPrinciples.Services;

try
{
    var user1 = new User("User1", "08856548484", "user1@gmail.com");
    var user2 = new User("User2", "08856512384", "user2@gmail.com");

    var emailChannel = new EmailChannel();
    var smsChannel = new SMSChannel();
    var pushNotificationChanel = new PushNotificationChannel();

    emailChannel.SendNotification(user1, user2, "Feel free to subscribe for our news.", DateTime.UtcNow.ToString(), "News subscription");
    smsChannel.SendNotification(user1, user2, "Your activation code is 985848", DateTime.Now.ToString());
    pushNotificationChanel.SendNotification(user1, user2, "Are you free?", DateTime.UtcNow.ToString());

    //We can pass different channels to services to perform notification sending
    var communicationService = new CommunicationService(emailChannel);
    var communicationService2 = new CommunicationService(smsChannel);
    var communicationService3 = new CommunicationService(pushNotificationChanel);

    communicationService.NotificateUser(user1, user2, "Feel free to subscribe for our news.", DateTime.UtcNow.ToString(), "News subscription");
    communicationService2.NotificateUser(user1, user2, "Your activation code is 985848", DateTime.Now.ToString());
    communicationService3.NotificateUser(null, user2, "Are you free?", DateTime.UtcNow.ToString());
}
catch (Exception ex)
{
    Console.WriteLine("Occured problem with sending notification to user.");
}