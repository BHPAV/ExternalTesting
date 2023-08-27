using System;
using System.Collections.Generic;
using System.Linq;
using Bespoke.Agent.Events;
using Bespoke.Agent.Events.TaskEvent;
using Bespoke.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Bespoke.Agent.Tasking
{
    [Title("Task Manager", TitleAlignment = TitleAlignments.Centered)]
    public class TaskManager : MonoBehaviour
    {
        [LabelText("Manager Name")] [BoxGroup("Manager Details")] [ShowInInspector, ReadOnly] 
        public string Name => "TaskSystem";
        
        [BoxGroup("Tasks")] [SerializeReference, InlineProperty, ShowInInspector] 
        public List<Task> tasks = new List<Task>();

        private List<BespokeEvent> _interestedEvents = new List<BespokeEvent>() { BespokeEvent.TaskComplete };

        [BoxGroup("Events")] [ShowInInspector] [SerializeReference]
        private TaskEventListener taskEventListener;
        
        
        
        
        

        // ------------------ Unity Methods ------------------ \\
        public void Start()
        {
            GetTask(0).StartTask();
            CreateTestEventListener();
        }
        
        public void Update()
        {
            foreach (var task in tasks)
            {
                task.Update();
            }
        }

        private void HandleTaskEvent(TaskEventData eventData)
        {
            Debug.Log($"Task Manager Ran This: Task {eventData.TaskId} changed status to {eventData.Status}");
        }

        public void CreateTestEventListener()
        {
            Action<TaskEventData> handleTaskEventDelegate = HandleTaskEvent;
            taskEventListener = new TaskEventListener(BespokeEvent.Complete, handleTaskEventDelegate);
        }
        
        
        
        
        
        // ------------------ Public Methods ------------------ \\
        public void AddTask(Task task) {
            tasks.Add(task);
            }

        public void RemoveTask(Task task) {
            tasks.Remove(task);
        }

        public bool IsTaskInList(Task task) {
            return tasks.Contains(task);
        }

        public Task GetTask(int index) {
            return tasks[index];
        }

        public List<Task> GetAllTasks() {
            return tasks;
        }
        
        
        // ------------------ Event Handlers ------------------ \\
        private void HandleTaskCompleted(Task task)
        {
            Debug.Log($"Task {task.name} is complete");
            CheckAllTasksComplete();
        }
        
        private void CheckAllTasksComplete()
        {
            if (tasks.All(task => task.IsComplete()))
            {
                Debug.Log("All tasks complete");
            }
        }

    }
}

