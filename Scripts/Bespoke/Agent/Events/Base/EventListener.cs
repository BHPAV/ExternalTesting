using System;
using System.Collections.Generic;
using Bespoke.Enums;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Events.Base
{
    [System.Serializable]
    public class EventListener
    {
        public EventManager eventManager;

        [ShowInInspector]
        [ValueDropdown("GetAllBespokeEvents")]
        public List<BespokeEvent> interestedEvents;

        private Dictionary<BespokeEvent, Action<EventData>> _eventHandlers;

        public EventListener()
        {
            eventManager = EventManager.Instance;
            _eventHandlers = new Dictionary<BespokeEvent, Action<EventData>>
            {
                { BespokeEvent.None, HandleEvent1 },
                { BespokeEvent.Grab, HandleEvent2 },
                // Add more handlers as needed for other BespokeEvent types
            };
        }


        public void OnEnable()
        {
            foreach (var bespokeEvent in interestedEvents)
            {
                //eventManager.Subscribe(bespokeEvent, _eventHandlers[bespokeEvent], interestedEvents);
            }
        }

        public void OnDisable()
        {
            foreach (var bespokeEvent in interestedEvents)
            {
                eventManager.Unsubscribe(bespokeEvent, _eventHandlers[bespokeEvent]);
            }
        }

        private void HandleEvent1(EventData eventData)
        {
            // Handle Event1
        }

        private void HandleEvent2(EventData eventData)
        {
            // Handle Event2
        }

        // Add more methods as needed for other BespokeEvent types

        private IEnumerable<BespokeEvent> GetAllBespokeEvents()
        {
            return (BespokeEvent[])Enum.GetValues(typeof(BespokeEvent));
        }
    }
}