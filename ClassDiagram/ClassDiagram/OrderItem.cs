namespace ClassDiagram
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
