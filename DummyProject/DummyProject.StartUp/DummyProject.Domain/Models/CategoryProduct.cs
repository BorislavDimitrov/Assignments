namespace DummyProject.Domain.Models
{
    public class CategoryProduct
    {
        public string CategoryId { get; set; }

        public string ProductId { get; set; }

        public Category Category { get; set; }

        public Product Product { get; set; }
    }
}
