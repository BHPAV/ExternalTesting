using System.Collections;
using System.Collections.Generic;
using Bespoke.Agent.Cores;
using UnityEngine;

namespace Bespoke.Agent.Cognition
{
    public abstract class AgentSubSystem : MonoBehaviour, IAgentSystem
    {
        protected AgentCore Agent;

        public virtual void Initialize(AgentCore agent)
        {
            Agent = agent;
        }

        public abstract void Update();
    }
}
