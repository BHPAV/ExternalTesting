using UnityEngine;
using Bespoke.Enums;
using Bespoke.Agent.Events;
using Bespoke.Agent.Events.Base;
using Bespoke.Agent.Events.Specific;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Scenarios
{
    public class ObjectToPositionHandler : MonoBehaviour
    {
        public GameObject goal;
        [ShowInInspector] private float _distance = 0;

        private void FixedUpdate()
        {
            _distance = Vector3.Distance(transform.position, goal.transform.position);
        }
        
        // OnCollisionEnter trigger the EventManager to trigger the BespokeEvent.Touch event
        private void OnCollisionEnter(Collision other)
        {
            //if(other.gameObject == goal)
                //EventManager.Instance.TriggerEvent(BespokeEvent.ObjectToPosition, new SpecificEventData(gameObject, Act.Touch, other.gameObject));
        }
    }
}