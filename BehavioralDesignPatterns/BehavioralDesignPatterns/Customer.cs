namespace BehavioralDesignPatterns
{
    public class Customer : IObserver
    {
        public string Id { get; set; } = new Guid().ToString();

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public void Update(string message)
        {
            Console.WriteLine($"The customer with name {this.Name} recieved email with the following message: {message}");
        }
    }
}
