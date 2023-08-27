using System.Collections.Generic;
using Bespoke.Agent.Rewards;
using Bespoke.Enums;
using Unity.MLAgents.Actuators;
using Bespoke.Agent.Events.RewardEvent;
using Bespoke.Agent.Tasking;
using Bespoke.InputSystem;
using UnityEngine;

namespace Bespoke.Agent.Cores
{
    public class AgentTrainingCore : AgentCore
    {
        // CONTROL SYSTEM ------------------------------------------------------------------
        private Dictionary<object, float> _processedInput;


        // EVENT HANDLERS ------------------------------------------------------------------
        //public event Action OnEpisodeEnd;
        [SerializeReference] public RewardManager rewardManager;

        //// STEP FUNCTIONS ---------------------------------------------------------------
        

        // AGENT FUNCTIONS ------------------------------------------------------------------

        public override void OnActionReceived(ActionBuffers actions)
        {
            // Pass the discrete actions to the input scheme, to announce input events.
            inputScheme.InputDiscreteActions(actions.DiscreteActions);
        }

        public override void Heuristic(in ActionBuffers actionsOut)
        {
            var discreteActionsOut = actionsOut.DiscreteActions;

            // Get the WASD values from the input scheme
            float[] wasdValues = inputScheme.GetWASDValues();

            // Map the WASD values to discrete actions (e.g., 0 for no action, 1 for action)
            // Assuming the discrete actions correspond to Up, Down, Left, Right in that order
            for (int i = 0; i < wasdValues.Length; i++)
            {
                discreteActionsOut[i] = wasdValues[i] > 0f ? 1 : 0;
            }
        }



        // Reset for the new episode =================================================================================
        public override void OnEpisodeBegin()
        {
            // Reset the agent
        }


        // INITIALIZATION FUNCTIONS ------------------------------------------------------------
        public override void Initialize()
        {
            base.Initialize();

            // Initialize the agent system manager
            //agentSystemManager.Initialize(this);
        }
    }
}