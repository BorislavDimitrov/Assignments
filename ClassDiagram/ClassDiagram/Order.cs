namespace ClassDiagram
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }  
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public decimal TotalPrice { get;  set; }
        public OrderStatus OrderStatus { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
    }
}
