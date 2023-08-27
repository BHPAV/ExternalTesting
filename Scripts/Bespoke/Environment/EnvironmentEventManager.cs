using System.Collections.Generic;
using UnityEngine;

namespace Bespoke.Environment
{
    public static class EnvironmentEventManager
    {
        

        public delegate void EnvironmentEvent(object eventData);
        private static Dictionary<string, EnvironmentEvent> _environmentEvents = new Dictionary<string, EnvironmentEvent>();

        public static void RegisterEvent(string eventName, EnvironmentEvent eventToRegister)
        {
            if (!_environmentEvents.ContainsKey(eventName))
            {
                _environmentEvents[eventName] = eventToRegister;
            }
            else
            {
                _environmentEvents[eventName] += eventToRegister;
            }
        }

        public static void TriggerEvent(string eventName, object eventData = null)
        {
            if (_environmentEvents.ContainsKey(eventName))
            {
                _environmentEvents[eventName]?.Invoke(eventData);
            }
        }
    }

}