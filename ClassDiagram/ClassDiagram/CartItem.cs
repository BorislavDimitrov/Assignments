namespace ClassDiagram
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
