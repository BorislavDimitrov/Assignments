namespace RepositoryAssignment
{
    public class Product : Entity
    {
        public string Title { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return $"Product with Title: {Title}, Price: {Price}, Quantity: {Quantity}, Description: {Description}";
        }
    }
}
