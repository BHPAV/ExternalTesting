using UnityEngine;

namespace Bespoke.Items
{



    public class DeliveryPoint : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var item = other.gameObject.GetComponent<Item>();
            var actor = other.gameObject.GetComponent<Actor>();

            if (item != null && actor != null)
            {
                DeliveryManager.Deliver(actor, item, this);
            }
        }
    }


}
