using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;



namespace Bespoke.Items
{
    public class ItemManager : MonoBehaviour
    {
        public List<Item> items = new List<Item>();

        public void Reset()
        {
            foreach (Item item in items)
            {
                item.Reset();
            }
        }
    }

    public class Item : MonoBehaviour
    {
        [HideInInspector] public Actor owner;
        [HideInInspector] public Actor placed;

        public enum Type
        {
            None,
            Resource,
            Hull,
            Weapon,
            Marker,
        }

        [BoxGroup("Item Details")] public Type type;

        public void Halt()
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }

        public void Reset()
        {
            owner = null;
            placed = null;
            Halt();
            RandomizePosition();
        }

        protected void RandomizePosition()
        {
            
        }

        public void SetOwner(Actor actor)
        {
            owner = actor;
        }
    }
}


