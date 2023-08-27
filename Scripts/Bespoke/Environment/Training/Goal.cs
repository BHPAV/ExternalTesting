using UnityEngine;
using Bespoke.Agent;
using Bespoke.Agent.Events;
using Bespoke.Enums;


namespace Bespoke.Training
{
    public class Goal : MonoBehaviour
    {
        //[SerializeField] private GameEvent arrivedAtGoalEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("item")) // Assuming the agent has a tag "Agent"
            {
                //GameObject agent = other.gameObject;
                //EventData eventData = new EventData(agent, Act.ArrivedAt, gameObject);
                //arrivedAtGoalEvent.Raise(eventData);
            }
        }


    }
}
