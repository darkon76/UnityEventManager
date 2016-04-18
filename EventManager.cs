using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    private EventArguments[] eventDictionary = new EventArguments[(int)eEvent.MAX];
    public delegate void EventArguments(object[] arg);

    /// <summary>
    /// Starts the listening an event.
    /// Its best to be called OnEnabled
    /// </summary>
    /// <param name="eventName">Event name.</param>
    /// <param name="listener">Listener.</param>
    public void Add(eEvent eventName, EventArguments listener)
    {
        eventDictionary[(int)eventName] += listener;
    }

    /// <summary>
    /// Stops the listening an Event.
    /// Its best to be called OnDisabled
    /// </summary>
    /// <param name="eventName">Event name.</param>
    /// <param name="listener">Listener.</param>
    public void Remove(eEvent eventName, EventArguments listener)
    {
          eventDictionary[(int)eventName] -= listener;
    }

    /// <summary>
    /// Triggers the event.
    /// </summary>
    /// <param name="eventName">Event name.</param>
    public void Trigger(eEvent eventName)
    {
        Trigger(eventName, null);
    }

    /// <summary>
    /// Triggers the event.
    /// </summary>
    /// <param name="eventName">Event name.</param>
    /// <param name="args">Arguments.</param>
    public void Trigger(eEvent eventName,params object[] args)
    {
        if (eventDictionary[(int)eventName] != null)
        {
            try
            {
                eventDictionary[(int)eventName](args);
            }
            catch { }
        }
    }
}