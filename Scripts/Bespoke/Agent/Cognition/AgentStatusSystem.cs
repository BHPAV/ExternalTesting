using System.Collections.Generic;
using System.Linq;

namespace Bespoke.Agent.Cognition
{
    public class AgentStatusSystem : AgentSubSystem, IAgentSystem
    {
        // Enum for different statuses
        public enum StatusType { Alive, Hungry, Tired, Poisoned }

        // Dictionary to hold statuses and their severity
        private Dictionary<StatusType, float> _statuses = new Dictionary<StatusType, float>();

        // Reference to the stats system to access agent's statistics
        private AgentStatsSystem _statsSystem;

        public void Initialize(AgentStatsSystem statsSystem)
        {
            // Initialization logic here
            this._statsSystem = statsSystem;
            _statuses[StatusType.Alive] = 1.0f; // Agent starts as alive
        }

        public void Initialize()
        {
            //throw new System.NotImplementedException();
        }

        public override void Update()
        {
            // Update logic for Hungry and Alive statuses
            // ...
        }

        // Method to set a specific status
        public void SetStatus(StatusType status, float severity)
        {
            _statuses[status] = severity;
        }

        // Method to get the most prominent status
        public StatusType GetMostProminentStatus()
        {
            return _statuses.OrderByDescending(s => s.Value).First().Key;
        }

        // Method to get all current status effects
        public List<StatusType> GetCurrentStatusEffects()
        {
            return _statuses.Where(s => s.Value > 0).Select(s => s.Key).ToList();
        }

        // Additional methods to manage and check statuses
    }

}
