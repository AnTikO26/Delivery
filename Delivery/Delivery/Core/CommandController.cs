using System.Collections.Generic;
using System;

namespace Delivery.Core;

public class CommandController
{
    public enum Command
    {
        sort_patient
    }

    Dictionary<Command, List<object>> events = new Dictionary<Command, List<object>>();
    public void Subscribe<T>(Command command, object subscriber, Action<T> callback)
    {
        if (!events.TryGetValue(command, out var subscribers))
        {
            subscribers = new List<object>();
            events[command] = subscribers;
        }

        subscribers.Add(new Subscriber<T>(subscriber, callback));
    }

    public void Publish<T>(Command command, T message)
    {
        if (events.TryGetValue(command, out var subscribers))
        {
            foreach (var subscriber in subscribers)
            {
                ((Subscriber<T>)subscriber).Callback(message);
            }
        }
    }
    private class Subscriber<T>
    {
        public object subscriber { get; }
        public Action<T> Callback { get; }

        public Subscriber(object _subscriber, Action<T> callback)
        {
            subscriber = _subscriber;
            Callback = callback;
        }
    }
}
