namespace BehavioralDesignPatterns
{
    public class Bookstore
    {
        public Order PlaceOrder(Customer customer, List<string> books, List<IObserver> workerObservers)
        {
            var newOrder = new Order
            {
               Books = books,
               CustomerId = customer.Id,
               OrderStatus = OrderStatus.Pending,
            };

            newOrder.AddObserver(customer);

            foreach (var observer in workerObservers)
            {
                newOrder.AddObserverTo(observer, OrderStatus.Pending);
                newOrder.AddObserverTo(observer, OrderStatus.ReadyForShipping);
            }

            newOrder.Notify(); 

            return newOrder;
        }

        public void ProcessOrder(Order order)
        {
            order.OrderStatus = OrderStatus.Processing;
            order.Notify();
            Console.WriteLine($"The order with id {order.Id} is being processed... it will take some time");
            order.OrderStatus = OrderStatus.ReadyForShipping;
            order.Notify();
        }

        public void ShipOrder(Order order)
        {
            Console.WriteLine($"The order with id {order.Id} has been shipped.");
            order.OrderStatus = OrderStatus.Shipped;
            order.Notify();
        }

        public void DeliverOrder(Order order)
        {
            Console.WriteLine($"The order with id {order.Id} has been delivered.");
            order.OrderStatus = OrderStatus.Delivered;
            order.Notify();
        }

        public void CancelOrder(Order order)
        {
            Console.WriteLine($"The order with id {order.Id} has been canceled.");
            order.OrderStatus = OrderStatus.Cancelled;
            order.Notify();
        }
    }
}
