using Bespoke.Agent.Events;
using UnityEngine;

namespace Bespoke.Items
{

    public class Recharger : MonoBehaviour
    {
        //[SerializeField] private GameEvent agentReachesRechargerEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("actor"))
            {
                //agentReachesRechargerEvent.Raise( ???? );
            }
        }
    }
}
