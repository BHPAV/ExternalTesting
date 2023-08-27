using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector;

namespace Bespoke.Items
{


    public class Deposit : Marker
    {
        [TabGroup("Deposit Details")] public int resourceAmount;
        [TabGroup("Deposit Details")] public GameObject depositZoneObject;
        [TabGroup("Deposit Details")] public Marker.MarkerType markerType = Marker.MarkerType.Deposit;


        [TabGroup("Deposit Details")] public Resource.SubType acceptedResource = Resource.SubType.Matter;
        
        private DepositZone depositZone;

        private void OnEnable() => DeliveryManager.OnDeposit += OnDeposit;                      // Subscribe to DeliveryManager events// Subscribe to DeliveryManager events
        private void OnDisable() => DeliveryManager.OnDeposit -= OnDeposit;                     // Unsubscribe from DeliveryManager events

        // Start is called before the first frame update
        void Start()
        {
            type = Item.Type.Marker;
            depositZone = depositZoneObject.gameObject.AddComponent<DepositZone>();
            depositZone.SetDeposit(this);
        }

        // Event handler for DeliveryManager.OnDeposit
        private void OnDeposit(Actor actor, Item item, Deposit deposit)
        {
            if (deposit != this) return;

        }
    }

    public class DepositZone : MonoBehaviour
    {
        [SerializeField] private Deposit deposit;

        public void SetDeposit(Deposit deposit) => this.deposit = deposit;

        private void OnTriggerEnter(Collider other)
        {
            var item = other.gameObject.GetComponent<Item>();
            if (item != null)
            {
                Debug.Log("Item entered deposit zone");
                DeliveryManager.Deposit(item.placed, item, deposit);
            }
        }
    }





}


