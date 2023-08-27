using System;

namespace Bespoke.Items
{

    public static class DeliveryManager
    {
        // Event to broadcast when delivery happens
        public static event Action<Actor, Item, DeliveryPoint> OnDelivery;
        public static event Action<Actor, Item, Deposit> OnDeposit;

        public static void Deliver(Actor actor, Item item, DeliveryPoint deliveryPoint)
        {
            // Add code here to process the delivery

            // Invoke the event
            OnDelivery?.Invoke(actor, item, deliveryPoint);
        }

        public static void Deposit(Actor actor, Item item, Deposit deposit)
        {
            // Add code here to process the delivery

            // Invoke the event
            OnDeposit?.Invoke(actor, item, deposit);
        }
    }

}
