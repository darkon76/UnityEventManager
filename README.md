# UnityEventManager

**Summary** 
An Event System is a fast way to communicate GameObject with the advantage that they don't need to know each other. 

**Usage**
1) Put the desire event at eEvent.
```csharp
public enum eEvent {
    RandomEventName,
    MAX
}
```
Enum are used to avoid errors, and it's easier to search event triggers and listeners. 


2) Create the function that listen to the Event Manager

```csharp 
void Foo(object[] args)
{
}
```
The array is for event communication, also when the code is read is easy to identify an event listener.

2.1) Listen to the Event Manager

```csharp
void OnEnable()
{
     EventManager.Instance.Add(eEvent.RandomEventName,OnFoo);
}
```
2.2) ***Important*** When you register a listener you need to unregister it. 
```csharp 
void OnDisable()
{
     EventManager.Instance.Remove(eEvent.RandomEventName,OnFoo);
}
```

A good practice is if you register at OnEnable and unregister at OnDisable. It works with Awake and OnDestroy. 


3) Trigger the event with 

```csharp 
void OnDisable()
{
     EventManager.Instance.Trigger(eEvent.RandomEventName, parameters);
}
```

###Bonus:###

The singleton, check EventManager.cs for integration. Be careful the singleton have the property of DontDestroyOnLoad. 
