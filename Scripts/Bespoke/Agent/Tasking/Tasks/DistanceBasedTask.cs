using UnityEngine;

using Sirenix.OdinInspector;

namespace Bespoke.Agent.Tasking.Tasks
{
    public class DistanceBasedTask : Task
    {
        [TabGroup("SPECIFIC")] [SerializeField] private Transform _obj1;
        [TabGroup("SPECIFIC")] [SerializeField] private Transform _obj2;
        [TabGroup("SPECIFIC")] [SerializeField] private float _distance;
        [TabGroup("SPECIFIC")] [SerializeField] private float _current;

        public DistanceBasedTask(Transform obj1, Transform obj2, float distance)
        {
            this._obj1 = obj1;
            this._obj2 = obj2;
            this._distance = distance;
        }

        
        
        public override void Update()
        {
            if (status == TaskStatus.InProgress)
            {
                
            }
                
        }
    }
}
