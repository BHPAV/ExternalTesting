using System.Collections.Generic;
using Unity.MLAgents.Actuators;

namespace Bespoke.InputSystem
{
    public class ContextInputScheme
    {
        private Dictionary<string, InputScheme> _contexts = new Dictionary<string, InputScheme>();
        private InputScheme _currentContext;

        public void AddContext(string contextName, InputScheme inputScheme)
        {
            _contexts[contextName] = inputScheme;
        }

        public void SwitchContext(string contextName)
        {
            if (_contexts.TryGetValue(contextName, out var context))
            {
                _currentContext = context;
            }
        }

        public void UpdateInputValues()
        {
            //_currentContext?.UpdateInputValues();
        }

        public void OnActionReceived(ActionSegment<int> discreteActions)
        {
            _currentContext.InputDiscreteActions(discreteActions);
        }

        // Other methods to delegate to the current context (e.g., GetDirectionValue, GetButtonValue)
    }
}
