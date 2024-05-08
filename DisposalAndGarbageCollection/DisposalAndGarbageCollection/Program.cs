using DisposalAndGarbageCollection;

try
{ 
    Console.WriteLine("Enter recipient email: ");
    string recipientEmail = Console.ReadLine();

    if (string.IsNullOrEmpty(recipientEmail))
    {
        throw new ArgumentNullException();
    }

    //The email you send from
    string gmailAddress = "tryemailsend@gmail.com\r\n";

    //Password generate from the SMTP server used to send the emails
    string appPassword = "oynj eyvh wmow gath";

    var emailSender = new EmailSender();
    await emailSender.SendEmailAsync(recipientEmail, "Newsletter Subscription", "Thank you for subscribing to the newsletter.", gmailAddress, appPassword);

    Console.WriteLine("Email sent successfully!");
}
catch
{
    Console.WriteLine("Something happend and the email was not sent successfully");
}
