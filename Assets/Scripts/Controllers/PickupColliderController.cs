using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class PickupColliderController : MonoBehaviour
    {
        public event EventHandler<OnPickupItemColledEventArgs> OnPickupItemCollide;
        public class OnPickupItemColledEventArgs
        {
            public PickupItemController pickupItemController;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent<PickupItemController>(out var pickupItemController))
                return;

            OnPickupItemCollide?.Invoke(this, new OnPickupItemColledEventArgs { pickupItemController = pickupItemController });

        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.TryGetComponent<PickupItemController>(out var pickupItemController))
                return;

            OnPickupItemCollide?.Invoke(this, new OnPickupItemColledEventArgs { pickupItemController = null });
        }
    }
}
