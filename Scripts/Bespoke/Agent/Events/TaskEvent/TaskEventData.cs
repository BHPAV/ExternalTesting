using System;
using Bespoke.Agent.Events.Base;
using Bespoke.Agent.Tasking;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Events.TaskEvent
{
    [Serializable]
    public class TaskEventData : EventData
    {
        [BoxGroup("Task Details")]
        [ShowInInspector]
        public Task Task { get; private set; }

        [BoxGroup("Task Details")]
        [ShowInInspector]
        public TaskStatus Status { get; private set; }        

        [BoxGroup("Task Details")]
        [ShowInInspector]
        public string TaskId { get; private set; }

        public TaskEventData(Task task, TaskStatus status)
        {
            Task = task;
            Status = status;
        }

        public TaskEventData(Task task, string taskId)
        {
            Task = task;
            Status = Task.status;
        }

        // TODO: Consider adding a method to update the status of the task.
        // TODO: Consider adding a method to validate the task details.
    }
}


