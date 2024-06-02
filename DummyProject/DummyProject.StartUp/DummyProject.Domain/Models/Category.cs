namespace DummyProject.Domain.Models
{
    public class Category
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public List<CategoryProduct> CategoryProduct { get; set; }
    }
}
