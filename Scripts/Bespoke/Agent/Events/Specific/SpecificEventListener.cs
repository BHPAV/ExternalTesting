using System;
using System.Collections.Generic;
using Bespoke.Agent.Events.Base;
using Bespoke.Enums;
using Sirenix.OdinInspector;


/*
 * This class, SpecificEventListener, is a generic class that listens for specific events of type T, where T is a subclass of EventData.
 * It subscribes to events it is interested in when enabled and unsubscribes when disabled.
 * When an event is triggered, it handles the event if the event data is of type T.
 * It also provides a method to get all bespoke events.
 */
namespace Bespoke.Agent.Events.Specific
{
    [Serializable]
    public class SpecificEventListener<T> where T : EventData
    {
        // ------------------ Properties ------------------ \\
        public EventManager eventManager = EventManager.Instance;

        [ShowInInspector] public List<BespokeEvent> interestedEvents;
        [ShowInInspector] public BespokeEvent listeningFor;

        
        
        // -------------------- DELEGATES -------------------- \\
        public Action<T> HandleEvent { get; set; } // Changed from Action<EventData> to Action<T>

        
        
        
        // ------------------ Public Methods ------------------ \\
        public void HandleEventWrapper(EventData eventData)
        {
            if (eventData is T tEventData)
            {
                HandleEvent?.Invoke(tEventData);
            }
        }

        public void Subscribe(BespokeEvent bespokeEvent)
        {
            eventManager.Subscribe(bespokeEvent, HandleEventWrapper);
        }

        public void Unsubscribe(BespokeEvent bespokeEvent)
        {
            eventManager.Unsubscribe(bespokeEvent, HandleEventWrapper);
        }

    }
}