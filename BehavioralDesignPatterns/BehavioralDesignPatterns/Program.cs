using BehavioralDesignPatterns;

var bookstore = new Bookstore();

var worker1 = new Worker { Name = "John" };
var worker2 = new Worker { Name = "Tom" };
var worker3 = new Worker { Name = "Harry" };

var customer1 = new Customer { Name = "Maria"};
var customer2 = new Customer { Name = "Charlie" };
var customer3 = new Customer { Name = "Liam" };

var books1 = new List<string> { "Pride and Prejudice by Jane Austen", "To Kill a Mockingbird by Harper Lee" };
var workers1 = new List<IObserver> { worker1, worker2 };
var order1 = bookstore.PlaceOrder(customer1, books1, workers1);
order1.AddObserver(worker3);
order1.RemoveObserver(worker3);

order1.AddObserverTo(worker3, OrderStatus.Shipped);
order1.AddObserverTo(worker3, OrderStatus.Delivered);

bookstore.ProcessOrder(order1);
bookstore.ShipOrder(order1);
bookstore.DeliverOrder(order1);

Console.WriteLine(new string('-', 150));

var books2 = new List<string> { "The Picture of Dorian Gray by Oscar Wilde", "Three Musketeers by Alexandre Dumas", "Dune by Frank Herbert" };
var workers2 = new List<IObserver> { worker2 };

var order2 = bookstore.PlaceOrder(customer2, books2, workers2);
order2.AddObserverTo(worker1, OrderStatus.Cancelled );
order2.AddObserverTo(worker1, OrderStatus.Shipped);
order2.RemoveObserverFrom(worker2, OrderStatus.Cancelled);
order2.RemoveObserverFrom(worker2, OrderStatus.Shipped);
order2.AddObserver(worker3);

bookstore.ProcessOrder(order2);
bookstore.ShipOrder(order2);
bookstore.DeliverOrder(order2);
bookstore.CancelOrder(order2);