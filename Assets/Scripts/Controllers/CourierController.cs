using UnityEngine;
using System.Collections;
using System;

namespace DeliveryDroneGame
{
    public class CourierController : MonoBehaviour
    {
        [SerializeField]
        private PickupColliderController pickupColliderController;
        [field: SerializeField]
        public Transform pickupPoint { get; private set; }

        private PickupItemController targetPickupItemController;
        private PickupItemController currentlyPickedUpItem;

        public event EventHandler OnPickupItemUpdateEvent;

        private void Awake()
        {
            pickupColliderController.OnPickupItemCollide += PickupColliderController_OnPickupItemCollide;
        }

        public void PickupItem()
        {
            if (currentlyPickedUpItem == null)
            {
                if (targetPickupItemController == null)
                    return;

                targetPickupItemController.SetCourierToFollow(this);
                currentlyPickedUpItem = targetPickupItemController;
            }
            else
            {
                currentlyPickedUpItem.SetCourierToFollow(null);
                currentlyPickedUpItem = null;
            }

            OnPickupItemUpdateEvent.Invoke(this, EventArgs.Empty);
        }

        private void PickupColliderController_OnPickupItemCollide(object sender, PickupColliderController.OnPickupItemColledEventArgs e)
        {
            targetPickupItemController = e.pickupItemController;
        }

        public PickupItemScriptableObject GetCurrentPickupItemInfo()
        {
            return currentlyPickedUpItem?.scriptableObject;
        }
    }
}
