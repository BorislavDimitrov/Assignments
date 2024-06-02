namespace DummyProject.Domain.Models
{
    public class OrderHistory
    {
        public string Id { get; set; }
        public string OrderId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public Order Order { get; set; }
    }
}
