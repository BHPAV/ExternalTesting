using Bespoke.Agent.Events;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Tasking.Tasks
{
    public class ObjectToGoal : Task
    {
        [TabGroup("SPECIFIC")][SerializeField] private GameObject _object;
        [TabGroup("SPECIFIC")][SerializeField] private GameObject _goal;
        [TabGroup("SPECIFIC")][SerializeField] private float _distance = 0.0f;

        public ObjectToGoal(GameObject obj1, GameObject obj2)
        {
            this._object = obj1;
            this._goal = obj2;
        }
        
        private void TaskCondition()
        {
            // Check if objects are within a certain distance of each other
            _distance = Vector3.Distance(_object.transform.position, _goal.transform.position);
            if (_distance < 1.0f)
            {
                CompleteTask();
            }
        }
        
        public override void Update()
        {
            if (status == TaskStatus.InProgress)
                TaskCondition();
        }
    }
}
