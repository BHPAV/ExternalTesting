using Bespoke.Agent.Events;
using Bespoke.Agent.Events.Base;
using Bespoke.Enums;
using UnityEngine;

namespace Bespoke.Items.Places
{
    public class GoalZone : MonoBehaviour
    {
        //[SerializeField] private GameEventListener ballIntoGoalListener;
        //[SerializeField] private GameEvent taskCompleteEvent;

        private void OnEnable()
        {
            //ballIntoGoalListener.response.AddListener(OnBallIntoGoal);
        }

        private void OnDisable()
        {
            //ballIntoGoalListener.response.RemoveListener(OnBallIntoGoal);
        }

        private void OnBallIntoGoal(EventData eventData)
        {
            // Perform the desired action
            //var taskCompleteData = new EventData(gameObject, Act.TaskComplete, null);
            //askCompleteEvent.Raise(taskCompleteData);
        }
    }
}
