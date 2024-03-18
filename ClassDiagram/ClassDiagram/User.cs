namespace ClassDiagram
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
        public List<Order> Orders { get; set; }
        public List<Vote> Votes { get; set; }
    }
}
