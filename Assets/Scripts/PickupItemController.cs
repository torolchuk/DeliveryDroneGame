using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class PickupItemController : MonoBehaviour
    {
        private Transform followPointTransform;

        public void SetCourierToFollow(CourierController courierController)
        {
            followPointTransform = courierController.pickupPoint;
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (followPointTransform == null)
                return;

            Vector3 movementVector = Vector3.Normalize(transform.position - followPointTransform.position);
            transform.position = transform.position + movementVector * 10 * Time.deltaTime;
        }
    }
}
