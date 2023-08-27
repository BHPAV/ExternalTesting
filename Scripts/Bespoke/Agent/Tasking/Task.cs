using Sirenix.OdinInspector;
using System;
using Bespoke.Agent.Events;
using Bespoke.Agent.Events.Base;
using Bespoke.Agent.Events.TaskEvent;
using Bespoke.Agent.Rewards;
using Bespoke.Enums;

namespace Bespoke.Agent.Tasking
{

    [Serializable]
    public class Task {

        /// <summary>
        ///  Agent Tasks are a low level task that can be broken down into multiple sub-tasks, but relates specifically to the agent's goals.
        ///  For example, an agent may have the task to "Write a CV". This task could be broken down into multiple sub-tasks, such as "Write a personal statement", "Write a list of skills", "Write a list of previous jobs" etc.
        ///  The task is the high level goal, and the sub-tasks are the steps required to achieve that goal.
        ///
        ///  Tasks can be assigned internally by the agent, or externally.
        ///  Tasks can be shared between agents.
        /// </summary>
        [TabGroup ("DETAILS")] public TaskPriority priority; // New property
        [TabGroup ("DETAILS")] public TaskStatus status;
        [TabGroup ("DETAILS")] public int weight; // New property

        [TabGroup ("DETAILS")] public float progress;
        [TabGroup ("DETAILS")] public string name;

        public void StartTask() {
            status = TaskStatus.InProgress;
        }

        public void CompleteTask()
        {
            status = TaskStatus.Completed;
            EventManager.Instance.TriggerEvent(BespokeEvent.Complete, new TaskEventData(this, name));
        }

        public bool IsComplete()
        {
            return status == TaskStatus.Completed;
        }

        public virtual void Update() {
            // Check status, update progress etc.
        }
    }

    // ENUMS ============================================================================================================
    public enum TaskStatus {
        NotStarted,
        InProgress,
        Completed
    }

    public enum TaskPriority
    {
        Low,
        Medium,
        High
    }
}
