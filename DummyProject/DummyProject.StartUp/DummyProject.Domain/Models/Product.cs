namespace DummyProject.Domain.Models
{
    public class Product
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public List<CategoryProduct> CategoryProduct { get; set; }

    }
}
