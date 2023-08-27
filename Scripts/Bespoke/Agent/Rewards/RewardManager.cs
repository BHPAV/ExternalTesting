using System;
using System.Collections.Generic;
using Bespoke.Agent.Events;
using Bespoke.Agent.Events.Base;
using Bespoke.Agent.Events.RewardEvent;
using Bespoke.Agent.Tasking;
using Bespoke.Enums;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Rewards
{
    [Serializable]
    [Title("Reward Manager", TitleAlignment = TitleAlignments.Centered)]
    public class RewardManager : MonoBehaviour
    {
        [BoxGroup("Reward System"), Title("Name")]
        public string Name => "RewardSystem";
        [BoxGroup("Reward System"), Title("Event Listeners")]
        private Dictionary<BespokeEvent, RewardEventListener> _eventListeners;

        [BoxGroup("Rewards"), Title("Rewards List")]
        public List<Reward> rewards = new List<Reward>();

        public RewardManager(TaskManager taskManager)
        {
            _eventListeners = new Dictionary<BespokeEvent, RewardEventListener>();
            EventManager.Instance.Subscribe(BespokeEvent.TaskComplete, HandleRewardEvent);
        }

        private void HandleRewardEvent(EventData eventData)
        {
            var rewardEventData = eventData as RewardEventData;
            if (rewardEventData != null)
            {
                Debug.Log($"Reward Event Listener Ran This: Agent {rewardEventData.agent} received reward {rewardEventData.reward}");
            }
        }

        public void ApplyReward(Reward reward)
        {
            // Logic to apply the reward
            Debug.Log($"Applying reward of value {reward.Value} with weight {reward.Weight}");
        }

        public void Reset()
        {
            // Logic to reset the rewards
            Debug.Log("Resetting rewards...");
            
            // Assuming you have a list of rewards, you can reset them here
            foreach (var reward in rewards)
            {
                 //reward.Reset();
            }
        }
    }
}