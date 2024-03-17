using System.Collections;

namespace C__Basics_and_.NET_Basics
{
    public class MyCustomList<T> : IEnumerable<T>
    {
        private T[] items;

        public MyCustomList()
        {
            items = new T[0];
        }

        public void Add(T item)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            //yield returns elements in reversed order
            for (int i = items.Length - 1; i >= 0; i--)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator(); 
        }
    }
}
