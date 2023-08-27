using UnityEngine;

namespace Bespoke.Environment
{
    public class Environment : MonoBehaviour
    {
        private ResetHandler _resetHandler;

        public void Initialize()
        {
            // Initialization code
            _resetHandler = new ResetHandler();
        }

        public void Reset()
        {
            _resetHandler.PerformReset();
        }

        public class ResetHandler
        {
            public void PerformReset()
            {
                // Reset logic
            }
        }
    }
}
