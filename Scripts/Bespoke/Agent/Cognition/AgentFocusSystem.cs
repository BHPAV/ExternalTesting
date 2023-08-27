using Bespoke.Agent.Cores;

namespace Bespoke.Agent.Cognition

{
    public class AgentFocusSystem : IAgentSystem
    {
        /// <summary>
        /// The AgentFocusSystem class manages the focus and attention of an agent.
        /// It keeps track of the current focus and the history of focus changes.
        /// </summary>


        private CurrentFocus _currentFocus;
        private FocusHistory _focusHistory;

        // Methods to manage focus and attention
        public void Initialize()
        {
            //throw new System.NotImplementedException();
        }

        public void Initialize(AgentCore agent)
        {
            
        }

        public void Update()
        {
            //throw new System.NotImplementedException();
        }
    }

    internal class FocusHistory
    {
    }

    internal class CurrentFocus
    {
    }
}
