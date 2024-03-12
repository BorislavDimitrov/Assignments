namespace DebbugingAndExceptionHandling
{
    public class User
    {
        public User(string name, string email, string phoneNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; }

        public string Email { get; }

        public string PhoneNumber { get; }

    }
}
