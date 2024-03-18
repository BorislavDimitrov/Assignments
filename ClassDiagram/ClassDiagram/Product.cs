namespace ClassDiagram
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string ImageUrl { get; set; }
        public bool InStock { get; set; }
        public List<Vote> Votes { get; set; }
        public List<Review> Reviews { get;}

        public List<Order> Orders { get; set; }
    }
}
