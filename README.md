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
Enums are used to avoid errors, and helps searching event triggers and listeners. 


2) Create the function that listens to the Event Manager

```csharp 
void Foo(object[] args)
{
}
```
The array is for event communication, as bonus it's easier to identify an event function.

2.1) Listen to the Event Manager

```csharp
void OnEnable()
{
     EventManager.Listen(eEvent.RandomEventName,OnFoo);
}
```
2.2) ***Important*** When you register a listener you need to unregister it. 
```csharp 
void OnDisable()
{
     EventManager.Remove(eEvent.RandomEventName,OnFoo);
}
```

A good practice is, if you register at OnEnable  unregister at OnDisable. It works the same way with Awake and OnDestroy. 

You can register a listener any place but always unregister it. 

3) Trigger the event with 

```csharp 
void OnDisable()
{
     EventManager.Trigger(eEvent.RandomEventName); //Trigger the listeners with null parameters.
     EventManager.Trigger(eEvent.RandomEventName, withParameters);
}
```

Trigger with the parameter enum, and all the parameters that we want to send. 
