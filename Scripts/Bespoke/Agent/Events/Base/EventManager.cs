using System;
using System.Collections.Generic;
using Bespoke.Enums;
using UnityEngine;


// Instructions to use EventManager Class
// 1. Access the singleton instance of EventManager using EventManager.Instance
// 2. Subscribe to an event using the Subscribe method. Pass the event, listener method and list of interested events.
// 3. Unsubscribe from an event using the Unsubscribe method. Pass the event and listener method.
// 4. Trigger an event using the TriggerEvent method. Pass the event and event data.
// 5. The EventManager handles thread safety, event history tracking and listener management.

namespace Bespoke.Agent.Events.Base
{
    public class EventManager : MonoBehaviour
    {
        // Singleton instance of the EventManager
        public static EventManager Instance { get; private set; }

        // Dictionary to store events and their listeners
        [SerializeReference]
        private Dictionary<BespokeEvent, List<(Action<EventData>, List<BespokeEvent>)>> _eventDictionary;

        // List to store the history of events
        [SerializeReference] private List<EventData> _eventHistory;

        // Object to lock threads when accessing shared resources
        private object _lockObject = new object();

        // Limit for the number of events stored in the history
        private int _eventHistoryLimit = 100;

        // Awake is called when the script instance is being loaded
        private void Awake()
        {
            // If there is no instance of EventManager, this instance becomes the singleton
            if (Instance == null)
            {
                Instance = this;
                // Initialize the event dictionary and history
                _eventDictionary = new Dictionary<BespokeEvent, List<(Action<EventData>, List<BespokeEvent>)>>();
                _eventHistory = new List<EventData>();
            }
            // If an instance already exists, destroy this object
            else
            {
                Destroy(gameObject);
            }
        }

        public void Subscribe(BespokeEvent bespokeEvent, Action<EventData> listener)
        {
            if (!_eventDictionary.ContainsKey(bespokeEvent))
            {
                _eventDictionary[bespokeEvent] = new List<(Action<EventData>, List<BespokeEvent>)>();
            }
            List<BespokeEvent> list = new List<BespokeEvent> { bespokeEvent };
            _eventDictionary[bespokeEvent].Add((listener, list));
        }

        public void Unsubscribe(BespokeEvent bespokeEvent, Action<EventData> listener)
        {
            if (_eventDictionary.TryGetValue(bespokeEvent, out var listeners))
            {
                var index = listeners.FindIndex(x => x.Item1 == listener);
                if (index != -1)
                {
                    listeners.RemoveAt(index);
                }
            }
        }

        // Method to trigger an event
        public void TriggerEvent(BespokeEvent bespokeEvent, EventData eventData)
        {
            // Lock the thread to prevent race conditions
            lock (_lockObject)
            {
                // If the event exists in the dictionary, invoke all listeners
                if (_eventDictionary.TryGetValue(bespokeEvent, out var value))
                {
                    foreach (var (listener, interestedEvents) in value)
                    {
                        // Only invoke the listener if it is interested in the event
                        if (interestedEvents.Contains(bespokeEvent))
                        {
                            listener.Invoke(eventData);
                        }
                    }

                    // Add the event to the history
                    _eventHistory.Add(eventData);

                    // Limit the size of eventHistory
                    while (_eventHistory.Count > _eventHistoryLimit)
                    {
                        _eventHistory.RemoveAt(0);
                    }
                }
                // Log a warning if there are no listeners for the event
                else
                {
                    Debug.LogWarning($"No listeners for event: {bespokeEvent}");
                }
            }
        }

        // TODO: Consider adding a method to clear event history
        // TODO: Consider adding a method to manually add events to the history
        // TODO: Consider adding a method to retrieve specific events from the history
        // TODO: Consider adding a method to change the event history limit
    }
}