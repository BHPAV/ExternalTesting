using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Bespoke.Agent;
using Bespoke.Agent.Cores;
using Bespoke.Agent.Events;
using Bespoke.Agent.Events.Base;
using Bespoke.Enums;

namespace Bespoke.Training
{
    public class TrainingManager : MonoBehaviour
    {

        public List<AgentCore> trainingAgents = new List<AgentCore>();

        // SETUP THE SCENE FOR TRAINING STUFF GOES HERE >>>>


        // THIS PART OF THE CODE TRIGGERS ALL THE RESETS AND REWARDS FOR THE TRAINING AGENTS >>>>


        // TEST EVENT FOR ARRIVAL AT GOAL. REMOVE THIS WHEN YOU HAVE YOUR OWN EVENT >>>>
        public void OnAgentArrivedAtGoal(EventData eventData)
        {
            //if (eventData.Action == Act.ArrivedAt)
            //{
                // Provide a reward to the agent (eventData.Source)
                // You can access the agent and goal GameObjects through eventData.Source and eventData.Target
                // Implement the logic for providing the reward here
                //Debug.Log(eventData.Source.name + " arrived at " + eventData.Target.name);
            //}
        }


    }
}
