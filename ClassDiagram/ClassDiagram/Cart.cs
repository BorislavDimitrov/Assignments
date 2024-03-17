namespace ClassDiagram
{
    public class Cart
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
