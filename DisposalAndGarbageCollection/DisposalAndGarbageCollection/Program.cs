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
    string gmailAddress = "testemailsendertestt@gmail.com\r\n";

    //Password generate from the SMTP server used to send the emails
    string appPassword = "kdjv vjpo jjpl kftp";

    var emailSender = new EmailSender();
    await emailSender.SendEmailAsync(recipientEmail, "Newsletter Subscription", "Thank you for subscribing to the newsletter.", gmailAddress, appPassword);

    Console.WriteLine("Email sent successfully!");
}
catch
{
    Console.WriteLine("Something happend and the email was not sent successfully");
}
