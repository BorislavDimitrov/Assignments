namespace ClassDiagram
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public int UserId { get; set; }  
        public string CardType { get; set; } 
        public string CardNumber { get; private set; } 
        public string ExpirationDate { get; private set; } 
        public bool IsDefault { get; set; }
        public List<Order> Orders { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
