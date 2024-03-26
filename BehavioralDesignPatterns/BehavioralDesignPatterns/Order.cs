namespace BehavioralDesignPatterns
{
    public class Order : ISubject
    {
        private Dictionary<OrderStatus, List<IObserver>> observers = new Dictionary<OrderStatus, List<IObserver>>();

        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CustomerId { get; set; }

        public List<string> Books { get; set; }

        public OrderStatus OrderStatus { get; set; }

        //Subscribe to all order status changes
        public void AddObserver(IObserver observer)
        {
            foreach (OrderStatus orderStatus in Enum.GetValues(typeof(OrderStatus)))
            {
                AddToDictionary(observer, orderStatus);
            }
        }

        //Subscribe to certain order status change
        public void AddObserverTo(IObserver observer, OrderStatus orderStatusToSubscribe)
        {
            AddToDictionary(observer, orderStatusToSubscribe);
        }

        // Remove subscriber from all order changes
        public void RemoveObserver(IObserver observer)
        {
            foreach (var key in observers.Keys)
            {
                observers[key].Remove(observer);
            }
        }

        //Remove subscriber from certain status code
        public void RemoveObserverFrom(IObserver observer, OrderStatus orderStatusSubscribedTo)
        {
            if (observers.ContainsKey(orderStatusSubscribedTo))
            {
                observers[orderStatusSubscribedTo].Remove(observer);
            }
        }

        public void Notify()
        {
            foreach (var subscribers in observers[this.OrderStatus])
            {
                subscribers.Update($"Order with id {this.Id} status has been updated to {this.OrderStatus}.");
            }
        }   

        private void AddToDictionary(IObserver observer, OrderStatus orderStatus)
        {
            if (observers.ContainsKey(orderStatus) == false)
            {
                observers[orderStatus] = new List<IObserver>();
            }
            observers[orderStatus].Add(observer);
        }
    }
}
