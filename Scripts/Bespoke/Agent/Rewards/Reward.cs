using System;
using Bespoke.Agent;
using Bespoke.Agent.Tasking;

// Reward class is used to provide a training reward to a Unity ML Agent
namespace Bespoke.Agent.Rewards
{
    [Serializable]
    public class Reward
    {
        public Task Task { get; set; }
        public float Value { get; set; }
        public float Weight { get; set; }
        public float Available { get; set; }
        
        public Reward(Task task, float value, float weight)
        {
            Task = task;
            Value = value;
            Weight = weight;
        }
        
        public void Reset()
        {
            // Reset the reward
        }
    }
}
