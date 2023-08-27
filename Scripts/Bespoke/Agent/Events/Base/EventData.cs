using System;
using Bespoke.Enums;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Events.Base
{
    
    [Serializable]
    public class EventData
    {
        // Common properties and methods for all event data
        [BoxGroup("Event Details")]
        [ShowInInspector]
        private BespokeEvent _type;
        [ShowInInspector]
        public BespokeEvent Type => _type;

        public EventData() { }

        public EventData(BespokeEvent bespokeEvent)
        {
            _type = bespokeEvent;
        }

        // TODO: Consider adding a method to validate the event type.
        // TODO: Consider adding a method to clone the event data.
    }
}
