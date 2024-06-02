namespace DummyProject.Domain.Models
{
    public class Order
    {
        public string Id { get; set; }

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
