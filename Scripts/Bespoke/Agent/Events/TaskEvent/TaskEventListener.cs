using System;
using System.Collections.Generic;
using Bespoke.Agent.Events.Specific;
using Bespoke.Agent.Events.TaskEvent;
using Bespoke.Enums;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

/*
 * The TaskEventListener class is a specific type of event listener that listens for TaskEventData events.
 * It extends the SpecificEventListener class with a type parameter of TaskEventData.
 *
 * To implement this class:
 * 1. Create an instance of TaskEventListener.
 * 2. Subscribe to the events you are interested in.
 * 3. Implement the HandleEvent method to define what should happen when a TaskEventData event is triggered.
 *
 * Example:
 * TaskEventListener taskEventListener = new TaskEventListener();
 * taskEventListener.Subscribe(someEvent);
 * taskEventListener.HandleEvent = (eventData) => { Debug.Log($"Task {eventData.TaskId} changed status to {eventData.Status}"); };
 */

namespace Bespoke.Agent.Events
{
    [Serializable]
    public delegate void HandleTaskEventDelegate(TaskEventData eventData);

    public class TaskEventListener : SpecificEventListener<TaskEventData>
    {
        public TaskEventListener(BespokeEvent bespokeEvent, Action<TaskEventData> handleEventDelegate)
        {
            listeningFor = bespokeEvent;
            HandleEvent = handleEventDelegate;
            
            Subscribe(bespokeEvent);
        }

        private void TaskEvent(TaskEventData eventData)
        {
            Debug.Log($"Task Event Listener Ran This {eventData.TaskId} changed status to {eventData.Status}. Event data: {eventData.Type}");
        }
    }
}
