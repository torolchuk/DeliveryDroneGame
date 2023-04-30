using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class PickupItemController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbodyRef;
        [SerializeField]
        private float movementSpeed = 5f;

        private Transform followPointTransform;

        public void SetCourierToFollow(CourierController courierController)
        {
            followPointTransform = courierController?.pickupPoint;

            rigidbodyRef.useGravity = followPointTransform == null;
            rigidbodyRef.isKinematic = false;
            transform.parent = null;
        }

        private void Update()
        {
            UpdatePosition();
        }

        private void UpdatePosition()
        {
            if (followPointTransform == null)
                return;

            transform.position = Vector3.MoveTowards(
                transform.position,
                followPointTransform.position,
                movementSpeed * Time.deltaTime
            );
        }
    }
}