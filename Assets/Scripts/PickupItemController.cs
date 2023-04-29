using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class PickupItemController : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody rigidbodyRef;
        private Transform followPointTransform;
        private Vector3 positionCache;
        private Vector3 targetPositionCache;

        public void SetCourierToFollow(CourierController courierController)
        {
            followPointTransform = courierController?.pickupPoint;

            rigidbodyRef.useGravity = followPointTransform == null;
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

            targetPositionCache = followPointTransform.position;
            positionCache = Vector3.MoveTowards(transform.position, targetPositionCache, 10f * Time.deltaTime);

            transform.position = targetPositionCache;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(positionCache, 1f);
            //Gizmos.DrawSphere(targetPositionCache, 1.5f);
        }
    }
}
