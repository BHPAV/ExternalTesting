using System;
using Bespoke.Agent.Cores;
using Bespoke.Agent.Events.Base;
using Bespoke.Agent.Tasking;
using Sirenix.OdinInspector;

namespace Bespoke.Agent.Events.RewardEvent
{
    [Serializable]
    [ShowOdinSerializedPropertiesInInspector]
    public class RewardEventData : EventData
    {
        [BoxGroup("Reward Details")] [ShowInInspector] public AgentCore agent { get; private set; }
        [BoxGroup("Reward Details")] [ShowInInspector] public float reward { get; private set; }
    }
}