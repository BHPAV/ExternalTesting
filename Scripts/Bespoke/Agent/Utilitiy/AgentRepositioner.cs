using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;


namespace Bespoke.Agent
{
    public class AgentRepositioner : MonoBehaviour
    {
        /*
        [SerializeField]
        private Transform[] spawnZones; // Spawn zones set in the Unity editor

        private AgentCore agent; // Reference to the agent

        private void Start()
        {
            agent = GetComponent<AgentCore>();
            agent.OnEpisodeEnd += HandleEpisodeEnd; // Subscribe to the episode end event
        }

        private void HandleEpisodeEnd()
        {
            // Reposition the agent based on the spawn zones and other criteria
            int spawnIndex = Random.Range(0, spawnZones.Length);
            agent.transform.position = spawnZones[spawnIndex].position;
        }

        private void OnDestroy()
        {
            agent.OnEpisodeEnd -= HandleEpisodeEnd; // Unsubscribe from the episode end event
        }
        */
        // Additional customization and methods as needed
    }

}
