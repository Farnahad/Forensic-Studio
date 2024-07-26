using Prism.Events;

namespace ForensicStudio.Core.Main.Event;

public class FsPubSubEvent : PubSubEvent
{
}

public class FsPubSubEvent<T> : PubSubEvent<T>
{
}