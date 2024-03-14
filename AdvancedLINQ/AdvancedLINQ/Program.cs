using AdvancedLINQ;

List<Customer> customers = new List<Customer>()
{
    { new Customer { Id = 1, Name = "Alice" } },
    { new Customer { Id = 2, Name = "Bob" } },
    { new Customer { Id = 3, Name = "Charlie" } },
};

List<Order> orders = new List<Order>()
{
    { new Order { CustomerId = 1, OrderNumber = "ORD100" } },
    { new Order { CustomerId = 2, OrderNumber = "ORD101" } },
    { new Order { CustomerId = 4, OrderNumber = "ORD102" } },
    { new Order { CustomerId = 1, OrderNumber = "ORD103" } },
    { new Order { CustomerId = 2, OrderNumber = "ORD104" } },
};

// Join
Console.WriteLine("Join Method-");

var customerOrders = customers.Join(
    orders,
    customer => customer.Id,
    order => order.CustomerId,
    (customer, order) => new { CustomerName = customer.Name, OrderNumber = order.OrderNumber });

foreach (var item in customerOrders)
{
    Console.WriteLine($"Customer: {item.CustomerName}, Order Number: {item.OrderNumber}");
}

// GroupJoin
Console.WriteLine("\nGroupJoin Method-");

var customerGroups = customers.GroupJoin(
    orders,
    customer => customer.Id,
    order => order.CustomerId,
    (customer, orderGroup) => new { Customer = customer, Orders = orderGroup });

foreach (var group in customerGroups)
{
    Console.WriteLine($"Customer: {group.Customer.Name}");
    foreach (var order in group.Orders)
    {
        Console.WriteLine($"\tOrder Number: {order.OrderNumber}");
    }
}

// Zip
Console.WriteLine("\nZip Method-");

List<string> mentors = new List<string>() { "David", "John", "Alice" };
List<string> students = new List<string>() { "Bob", "Charlie", "Marie", "Chuckie" };

var mentorsStudentsPairs = mentors.Zip(students, (mentor, student) => new { Mentor = mentor, Student = student });

foreach (var pair in mentorsStudentsPairs)
{
    Console.WriteLine($"Mentor: {pair.Mentor}, Student: {pair.Student}");
}

// GroupBy
Console.WriteLine("\nGroupBy Method-");

List<Person> people = new List<Person>()
{
    new Person { Name = "Alice", City = "New York" },
    new Person { Name = "Bob", City = "London" },
    new Person { Name = "Charlie", City = "New York" },
    new Person { Name = "David", City = "Paris" },
    new Person { Name = "Emily", City = "New York" },
};

var peopleByCity = people.GroupBy(person => person.City);

foreach (var group in peopleByCity)
{
    Console.WriteLine($"City: {group.Key}");
    foreach (var person in group)
    {
        Console.WriteLine($"\tPerson Name: {person.Name}");
    }
}

// Concat
Console.WriteLine("\nConcat Method-");

List<int> startingNumbers = new List<int>() { 1, 2, 3, 4, 5 };
List<int> endingNumbers = new List<int>() { 6, 7, 8, 9, 10};

var concatNumbers = startingNumbers.Concat(endingNumbers);

Console.WriteLine(string.Join(" ", concatNumbers));

// Union
Console.WriteLine("\nUnion Method-");

List<int> numbers1 = new List<int>() { 1, 2, 3, 4, 5, 6 };
List<int> numbers2 = new List<int>() { 5, 6, 7, 8, 9, 10 };

var allNumbers = numbers1.Union(numbers2);

Console.WriteLine(string.Join(" ", allNumbers));

// Intersect
Console.WriteLine("\nIntersect Method-");

List<string> fruits1 = new List<string>() { "Apple", "Banana", "Orange", "Watermelon" };
List<string> fruits2 = new List<string>() { "Banana", "Grape", "Mango", "Watermelon", "Apple" };

var commonFruits = fruits1.Intersect(fruits2);

Console.WriteLine(string.Join(" ", commonFruits));

// Except
Console.WriteLine("\nExcept Method-");

List<string> vegetables1 = new List<string>() { "Carrot", "Potato", "Tomato" };
List<string> vegetables2 = new List<string>() { "Potato", "Broccoli", "Spinach" };

var uniqueVegetables = vegetables1.Except(vegetables2);

Console.WriteLine(string.Join(" ", uniqueVegetables));

// Count 
Console.WriteLine("\nCount Method-");

List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };
int count = numbers.Count();
Console.WriteLine($"Number of elements: {count}");

List<Person> peopleSalaries = new List<Person>()
{
  { new Person { Salary = 87421.00 } },
  { new Person { Salary = 59382.50 } },
  { new Person { Salary = 112967.78 } },
  { new Person { Salary = 48153.25 } },
  { new Person { Salary = 139840.62 } },
  { new Person { Salary = 62507.10 } },
  { new Person { Salary = 95238.94 } },
  { new Person { Salary = 33714.89 } },
  { new Person { Salary = 101472.31 } },
  { new Person { Salary = 78956.04 } },
};

// Min
Console.WriteLine("\nMin Method-");
var minAnnualSalary = peopleSalaries.Min(x => x.Salary);
Console.WriteLine(minAnnualSalary);

// Max 
Console.WriteLine("\nMax Method-");
var maxAnnualSalary = peopleSalaries.Max(x => x.Salary);
Console.WriteLine(maxAnnualSalary);

// Average
Console.WriteLine("\nAverage Method-");
var averageAnnualSalary = peopleSalaries.Average(x => x.Salary);
Console.WriteLine(averageAnnualSalary);

var sequenceOfWords = new List<string>() { "Amdaris", "Internship", "Programme" };

// Aggregate
Console.WriteLine("\nAggregate Method-");
string aggregatedSentence = sequenceOfWords.Aggregate(string.Empty, (current, next) => current + next + " ");
Console.WriteLine(aggregatedSentence);


// Contains
Console.WriteLine("\nContains Method-");
var isContaining = sequenceOfWords.Contains("Amdaris");
Console.WriteLine(isContaining);

// Any
Console.WriteLine("\nAny Method-");
var any = sequenceOfWords.Any(x => x.StartsWith("A") && x.EndsWith("s"));
Console.WriteLine(any);

// All
Console.WriteLine("\nAll Method-");
var all = sequenceOfWords.All(x => x.Length > 0);
Console.WriteLine(all);

// SequenceEqual
Console.WriteLine("\nSequenceEqual Method-");

List<int> ints1 = new List<int>() { 1, 2, 3 };
List<int> ints2 = new List<int>() { 1, 2, 3, 4 };
var areEqual = ints1.SequenceEqual(ints2);
Console.WriteLine(areEqual);

List<object> mixedList = new List<object>() { 10, "hello", 3.14, true, 5, 5.6 };

// OfType
Console.WriteLine("\nOfType Method-");
List<int> integers = mixedList.OfType<int>().ToList();
Console.WriteLine("Integers:" + string.Join(" ", integers));

// Cast
Console.WriteLine("\nCast Method-");

try
{
    List<double> doubles = mixedList.Cast<double>().ToList();
}
catch (InvalidCastException)
{
    Console.WriteLine("Casting failed for some elements.");
}

List<string> names = new List<string>() { "Alice", "Bob", "Charlie" };

// ToArray
Console.WriteLine("\nToArray Method-");
string[] namesArray = names.ToArray();
Console.WriteLine("Names as array:" + string.Join(", ", namesArray));

// ToList
Console.WriteLine("\nToList Method-");
List<string> namesList = namesArray.ToList();
Console.WriteLine("Names as list:" + string.Join(", ", namesList));

// ToDictionary
Console.WriteLine("\nToDictionary Method-");

List<Person> people2 = new List<Person>()
{
  { new Person { Id = 1, Name = "Alice" } },
  { new Person { Id = 2, Name = "Bob" } },
  { new Person { Id = 3, Name = "Charlie" } },
};

Dictionary<int, string> dict = people2.ToDictionary(person => person.Id, person => person.Name);

foreach (KeyValuePair<int, string> entry in dict)
{
    Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value}");
}

// ToLookup
Console.WriteLine("\nToLookup Method-");

List<Order> orders2 = new List<Order>()
{
  { new Order { ProductId = 1, CustomerId = 1 } },
  { new Order { ProductId = 2, CustomerId = 1 } },
  { new Order { ProductId = 3, CustomerId = 2 } },
  { new Order { ProductId = 1, CustomerId = 3 } },
};

ILookup<int, Order> ordersByCustomer = orders2.ToLookup(order => order.CustomerId);

Console.WriteLine("Orders by customer:");
foreach (var customerGroup in ordersByCustomer)
{
    Console.WriteLine($"Customer ID: {customerGroup.Key}");
    foreach (Order order in customerGroup)
    {
        Console.WriteLine($"\tProduct ID: {order.ProductId}");
    }
}

// AsQueryable
Console.WriteLine("\nAsQueryable Method-");

List<Product> products = new List<Product>()
{
  { new Product { Id = 1, Name = "Shirt", Price = 25.99 } },
  { new Product { Id = 2, Name = "Hat", Price = 19.95 } },
  { new Product { Id = 3, Name = "Jeans", Price = 55.50 } },
  { new Product { Id = 4, Name = "Shoes", Price = 74.99 } },
};

IQueryable<Product> queryableProducts = products.AsQueryable();

var expensiveProducts = queryableProducts.Where(p => p.Price > 50.00);

foreach (Product product in expensiveProducts)
{
    Console.WriteLine($"Expensive product: {product.Name} ({product.Price:C2})");
}

List<string> colors = new List<string>() { "red", "green", "blue" };
List<string> emptyColors = new List<string>();

// First, FirstOrDefault
Console.WriteLine("\nFirst and FirstOrDefault Methods-");

try
{
    string firstColor = colors.First();
    Console.WriteLine(firstColor);

    string firstEmptyColor = emptyColors.First();
    Console.WriteLine(firstEmptyColor);
}
catch (InvalidOperationException)
{
    Console.WriteLine("Empty list has no first element.");
}

string firstOrDefailtEmptyColor = emptyColors.FirstOrDefault();
Console.WriteLine(firstOrDefailtEmptyColor);

string firstOrDefault = colors.FirstOrDefault();
Console.WriteLine(firstOrDefault);

// Last, LastOrDefault
Console.WriteLine("\nLast and LastOrDefault Methods-");

try
{
    string lastColor = colors.Last();
    Console.WriteLine(lastColor);

    string lastEmptyColor = emptyColors.Last();
    Console.WriteLine(lastEmptyColor);
}
catch (InvalidOperationException)
{
    Console.WriteLine("Empty list has no last element.");
}

string LastOrDefailtEmptyColor = emptyColors.LastOrDefault();
Console.WriteLine(LastOrDefailtEmptyColor);

string LastOrDefault = colors.LastOrDefault();
Console.WriteLine(LastOrDefault);

// ElementAt, ElementAtOrDefault
Console.WriteLine("\nElementAt and ElementAtOrDefault Methods-");

List<string> fruits = new List<string>() { "apple", "banana", "orange" };

try
{
    string secondFruit = fruits.ElementAt(1);
    Console.WriteLine(secondFruit);

    string outOfBoundsFruit = fruits.ElementAt(5);
    Console.WriteLine(outOfBoundsFruit);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine("The index you want to access is out of the bounds of the array");
}

string secondOrEmptyFruit = fruits.ElementAtOrDefault(1);
Console.WriteLine(secondOrEmptyFruit);

string outOfBoundsOrEmptyFruit = fruits.ElementAtOrDefault(5);
Console.WriteLine(outOfBoundsOrEmptyFruit);

// DefaultIfEmpty
Console.WriteLine("\nDefaultIfEmpty Methods-");

List<string> emptyList = new List<string>();
List<string> nonEmptyList = new List<string>() { "hello", "bye" };

IEnumerable<string> emptyResult = emptyList.DefaultIfEmpty();
Console.WriteLine(emptyResult.Count());

IEnumerable<string> nonEmptyResult = nonEmptyList.DefaultIfEmpty();
Console.WriteLine(nonEmptyResult.Count());

// Empty
Console.WriteLine("\nEmpty Method-");
var emptyCollection = Enumerable.Empty<string>();
Console.WriteLine(emptyCollection.Count());

// Repeat
Console.WriteLine("\nRepeat Method-");
var repeatCollection = Enumerable.Repeat(new Person(), 5);
Console.WriteLine(repeatCollection.Count());

// Range
Console.WriteLine("\nRange Method-");
var rangeCollection = Enumerable.Range(1, 50);
Console.WriteLine(rangeCollection.Count());