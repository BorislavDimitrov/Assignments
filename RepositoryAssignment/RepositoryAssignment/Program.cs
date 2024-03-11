using RepositoryAssignment;

var productsRepo = new Repository<Product>();

var book = new Product { Title = "Book", Price = 30, Quantity = 10, Description = "Some book" };
productsRepo.Add(book);

var shirt = new Product { Title = "Shirt", Price = 40, Quantity = 20, Description = "Some shirt" };
productsRepo.Add(shirt);

var shoes = new Product { Title = "Shoes", Price = 35, Quantity = 1, Description = "Some shoes" };
productsRepo.Add(shoes);

var ball = new Product { Title = "Ball", Price = 10, Quantity = 5, Description = "Some ball" };
productsRepo.Add(ball);

var jeans = new Product { Title = "Jeans", Price = 32, Quantity = 1, Description = "Some jeans" };
productsRepo.Add(jeans);

var allProducts  = productsRepo.GetAll();

foreach (var product in allProducts)
{
    Console.WriteLine(product.ToString());
}

var ballById = productsRepo.GetById(ball.Id);
Console.WriteLine(ballById);

productsRepo.Delete(book);

productsRepo.DeleteById(shirt.Id);

var productsToRemove = new List<Product>() { shoes, ball };

productsRepo.RemoveRange(productsToRemove);

Console.WriteLine($"Count of products is {productsRepo.GetCount()}");