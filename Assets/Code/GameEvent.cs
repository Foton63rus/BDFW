using System;
using System.Collections.Generic;
using UnityEngine;

namespace BDFW
{
    internal sealed class GameEvent
    {
        private static GameEvent _instance;
        public GameEvent Instance => _instance;

        internal Dictionary<int, HashSet<object>> _subscribers;
        internal GameEvent() 
        {
            
            if (_instance == null)
            {
                _instance = this;
                _subscribers = new Dictionary<int, HashSet<object>>();
            }
            else
            {
                throw new Exception("GameEvent Instance not null");
            }
        }

        internal void Invoke<T>(T eventData) where T : struct
        {
            Debug.Log($"data");
            if (_subscribers.TryGetValue(typeof(T).GetHashCode(), out var subscriberList))
            {

                foreach (ISubscribe<T> subscriber in subscriberList)
                {
                    subscriber?.EventHandler(in eventData);
                }
                EventPool<T>.Release(eventData);
            }
        }

        internal void Add<T>(ISubscribe<T> subscriber) where T : struct
        {

            var type = typeof(T);
            if (!_subscribers.TryGetValue(type.GetHashCode(), out var set))
            {
                set = new HashSet<object>();
                _subscribers[type.GetHashCode()] = set;
            }
            set.Add(subscriber);
        }

        void Remove(ISubscribe recieve, Type type)
        {
            if (!_subscribers.TryGetValue(type.GetHashCode(), out var subscriberList))
                return;
            subscriberList.Remove(recieve);
        }

        internal void Remove(object obj)
        {
            var interfaces = obj.GetType().GetInterfaces();
            var subscriber = obj as ISubscribe;
            foreach (var type in interfaces)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ISubscribe<>))
                    Remove(subscriber, type.GetGenericArguments()[0]);
            }
        }

        internal void OnDispose()
        {
            _subscribers.Clear();
        }
    }

    #region interfaces
    interface ISubscribe { }
    interface ISubscribe<T>// where T : struct
    {
        public void EventHandler(in T arg);
    }
    #endregion interfaces
}
