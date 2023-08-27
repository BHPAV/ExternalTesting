using Bespoke.Agent.Cores;

namespace Bespoke.Agent.Cognition
{
    public interface IAgentSystem
    {
        void Initialize(AgentCore agent);
        void Update();
    }
}