using System.Collections.Generic;

namespace BDFW
{
    internal class EventPool<T> where T : struct
    {
        private static readonly Queue<T> _pool = new Queue<T>();

        public static T Get()
        {
            return _pool.Count > 0 ? _pool.Dequeue() : new T();
        }

        public static void Release(T eventData) 
        {
            _pool.Enqueue(eventData);
        }

        public static void Clear()
        {
            _pool.Clear();
        }
    }
}
