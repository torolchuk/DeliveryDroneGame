using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class AvatarController : MonoBehaviour
    {
        private Vector2 movementVector;
        private Vector2 targetMovementVector;

        [SerializeField]
        [Range(0f, 1f)]
        private float movementInertia = .9f;
        [SerializeField]
        private float movementSpeed;

        public void SetMovementVector(Vector2 targetVector)
        {
            targetMovementVector = targetVector;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            movementVector = Vector2.Lerp(
                movementVector,
                targetMovementVector,
                movementInertia
            );

            if (movementVector == Vector2.zero)
                return;

            Vector3 transformedMovementVector = new Vector3(
                movementVector.x,
                0,
                movementVector.y
            );

            transform.Translate(transformedMovementVector * movementSpeed * Time.deltaTime);
        }
    }
}
