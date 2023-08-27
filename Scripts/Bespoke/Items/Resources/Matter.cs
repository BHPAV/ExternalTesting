using System;
using UnityEngine;

using Sirenix.OdinInspector;
using Bespoke;


namespace Bespoke.Items
{
    public class Matter : Resource
    {




        private void FixedUpdate() {

            // If below the ground, reset the position.
            /*
            if(transform.position.y < -1)
            {
                Halt();
                RandomizePosition();
            }

            // If the item is being held and is more than 2 units away from the actor, halt the item, remove the owner and drop the item.
            if(owner != null && Vector3.Distance(transform.position, owner.transform.position) > 2)
            {
                Halt();
                //owner.DropItem(this);
                owner = null;
                transform.parent = originalParent.transform;
            }
            */
        }

        private void Pickup(Actor actor)
        {
            /*
            if(actor.PickUpItem(this))
            {
                // The actor is able to pick up the item.
                // The actor picks up the item.
                owner = actor;
                placed = actor;
                transform.parent = actor.transform; // Attach the item to the actor.

                // Disable the item's rigidbody.
                Rigidbody rb = GetComponent<Rigidbody>();
                rb.isKinematic = true;
                rb.useGravity = false;

                transform.localPosition = Vector3.up * holdHeight; // Position the item above the actor.
                transform.localRotation = Quaternion.identity; // Reset the item's rotation.

                OnPickup?.Invoke(owner); // Invoke the OnPickup event.
            }
            */
        }


        private void Throw()
        {
            /*
            OnDrop?.Invoke(owner);                                                                       // Invoke the OnDrop event.

            // Throw the item. Reenable the rigidbody and Add throw power to the item's forward vector.
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = false;                                                                     // Reenable the item's rigidbody.
            rb.useGravity = true;                                                                       // Reenable gravity on the item.

            transform.localPosition = Vector3.up * holdHeight;

            rb.AddForce(owner.transform.up * throwPower /2, ForceMode.Impulse);                         // Throw the item Up.
            rb.AddForce(owner.transform.forward * throwPower *2, ForceMode.Impulse);                    // Throw the item Forward.

            //transform.position = owner.transform.position + owner.transform.forward * throwPower;     // Throw the item forward.

            owner.DropItem(this);                                                                       // Drop the item.
            owner = null;
            transform.parent = originalParent.transform;                                                // Detach the item from the actor.
            */
        }

        private void Place()
        {
            /*
            OnDrop?.Invoke(owner);                                                                       // Invoke the OnDrop event.

            // place the object on the ground in front of the actor
            transform.position = owner.transform.position + owner.transform.forward / 1.25f;

            Rigidbody rb = GetComponent<Rigidbody>();
                rb.isKinematic = false;
                rb.useGravity = true;

            owner.DropItem(this);
            owner = null;
            transform.parent = originalParent.transform;
            */
        }


    }
}


