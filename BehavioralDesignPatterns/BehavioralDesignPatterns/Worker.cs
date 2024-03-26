namespace BehavioralDesignPatterns
{
    public class Worker : IObserver
    {
        public string Name { get; set; }

        public void Update(string message)
        {
            Console.WriteLine($"The worker with name {this.Name} recieved email with the following message: {message}");
        }
    }
}
