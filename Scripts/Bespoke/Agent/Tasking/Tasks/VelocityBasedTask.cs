using UnityEngine;

namespace Bespoke.Agent.Tasking.Tasks
{
    public class VelocityBasedTask : Task
    {
        private Rigidbody _rb;
        private float _velocityThreshold;

        public VelocityBasedTask(Rigidbody rb, float velocityThreshold)
        {
            this._rb = rb;
            this._velocityThreshold = velocityThreshold;
        }

        
    }
}
