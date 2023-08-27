using System.Collections;
using System.Collections.Generic;
using Bespoke.Agent.Cognition;
using Bespoke.Agent.Cores;
using Bespoke.Agent.Tasking;
using UnityEngine;

namespace Bespoke.Agent
{
    public class AgentSystemManager : MonoBehaviour
    {
        // This class will manage all the different additions to the Agent to Extend it's intelligence and capabilities.
        // It will be responsible for initializing and updating all the different systems.
        private AgentCore _agent;

        // Keep these for inspection in the Unity editor
        public AgentMemorySystem MemoryManager;
        public AgentFocusSystem FocusManager;
        public AgentPersonalitySystem PersonalityManager;

        private List<IAgentSystem> _agentSystems;

        public void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            // Initialize the concrete classes
            MemoryManager = new AgentMemorySystem();
            FocusManager = new AgentFocusSystem();
            PersonalityManager = new AgentPersonalitySystem();

            // Add them to the list as IAgentSystem
            _agentSystems = new List<IAgentSystem>
            {
                MemoryManager,
                FocusManager,
                PersonalityManager
                // Add other systems here...
            };

            foreach (var system in _agentSystems)
            {
                system.Initialize(_agent);
            }
        }


    }
}
