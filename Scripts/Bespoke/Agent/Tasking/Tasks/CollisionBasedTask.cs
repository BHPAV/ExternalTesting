using UnityEngine;

namespace Bespoke.Agent.Tasking.Tasks
{
    public class CollisionBasedTask : Task
    {
        private Collider _collider1;
        private Collider _collider2;

        public CollisionBasedTask(Collider collider1, Collider collider2)
        {
            this._collider1 = collider1;
            this._collider2 = collider2;
        }

        
    }
}
