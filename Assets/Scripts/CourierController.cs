﻿using UnityEngine;
using System.Collections;

namespace DeliveryDroneGame
{
    public class CourierController : MonoBehaviour
    {
        [SerializeField]
        private PickupColliderController pickupColliderController;
        [field: SerializeField]
        public Transform pickupPoint { get; private set; }

        private PickupItemController targetPickupItemController;

        private void Awake()
        {
            pickupColliderController.OnPickupItemCollide += PickupColliderController_OnPickupItemCollide;
        }

        public void PickupItem()
        {
            if (targetPickupItemController == null)
                return;

            targetPickupItemController.SetCourierToFollow(this);
        }

        private void PickupColliderController_OnPickupItemCollide(object sender, PickupColliderController.OnPickupItemColledEventArgs e)
        {
            targetPickupItemController = e.pickupItemController;
        }
    }
}
