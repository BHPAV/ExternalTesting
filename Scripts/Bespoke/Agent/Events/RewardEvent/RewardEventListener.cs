using System;
using Bespoke.Agent.Events.Specific;
using Bespoke.Enums;
using UnityEngine;

namespace Bespoke.Agent.Events.RewardEvent
{
    public delegate void HandleRewardEventDelegate(RewardEventData eventData);
    
    public class RewardEventListener : SpecificEventListener<RewardEventData>
    {
        public RewardEventListener(BespokeEvent bespokeEvent, Action<RewardEventData> handleEventDelegate)
        {
            listeningFor = bespokeEvent;
            HandleEvent = handleEventDelegate;
            
            Subscribe(bespokeEvent);
        }
        
        private void RewardEvent(RewardEventData eventData)
        {
            Debug.Log($"Task Reward Listener");
        }
    }
}