using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class PickupItemController : MonoBehaviour
    {

        private enum State
        {
            Waiting,
            FolowingCourier,
            Dropped,
            SelfDestruction
        }

        private State currentState = State.Waiting;

        [SerializeField]
        private Rigidbody rigidbodyRef;
        [SerializeField]
        private float movementSpeed = 5f;
        [field: SerializeField]
        public PickupItemScriptableObject scriptableObject { get; private set; }
        [SerializeField]
        private float timeToSelfDestroy = 2f;
        [SerializeField]
        private EmptyGameEvent pickupItemLostGameEvent;

        private Transform followPointTransform;

        public void SetCourierToFollow(CourierController courierController)
        {
            if (currentState == State.SelfDestruction)
            {
                StopCoroutine("SelfDestroyCoroutine");
            }

            followPointTransform = courierController?.pickupPoint;
            currentState = followPointTransform != null ? State.FolowingCourier : State.Dropped;


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

        private void OnCollisionEnter(Collision collision)
        {
            if (currentState != State.Waiting && currentState != State.FolowingCourier)
            {
                transform.parent = collision.transform;
            }

            if (currentState == State.Dropped)
            {
                StartCoroutine("SelfDestroyCoroutine");
            }
        }

        private IEnumerator SelfDestroyCoroutine()
        {
            currentState = State.SelfDestruction;
            yield return new WaitForSeconds(timeToSelfDestroy);
            pickupItemLostGameEvent.Invoke(this, EventArgs.Empty);
            Destroy(gameObject);
        }
    }
}