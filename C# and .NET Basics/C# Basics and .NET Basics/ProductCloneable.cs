namespace C__Basics_and_.NET_Basics
{
    public class ProductCloneable : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<ProductTag> ProductTags { get; set; } 

        public object Clone()
        {
            // Option 1: Shallow Copy using MemberwiseClone()
            // return this.MemberwiseClone();

            // Option 2: Deep Copy 
            return new ProductCloneable
            {
                Id = this.Id,
                Name = this.Name,
                Price = this.Price,
                ProductTags = new List<ProductTag>(this.ProductTags) // Deep copy the ProductTags collection
            };
        }
    }
}
