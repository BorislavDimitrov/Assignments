namespace BehavioralDesignPatterns
{
    public interface ISubject
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void AddObserverTo(IObserver observer, OrderStatus orderStatus);
        void RemoveObserverFrom(IObserver observer, OrderStatus orderStatusSubscribedTo);
        void Notify();
    }
}
