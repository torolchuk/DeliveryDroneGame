using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private PlayerInputListener playerInputListener;
        [SerializeField]
        private AvatarController avatarController;
        [SerializeField]
        private DroneVisualsController droneVisualsController;
        [SerializeField]
        private CourierController courierController;

        private PickupItemController pickupItemController;

        private Vector2 movementVector;

        private void Awake()
        {
            playerInputListener.OnMovePerformed += PlayerInputListener_OnMovePerformed;
            playerInputListener.OnInteractPerformed += PlayerInputListener_OnInteractPerformed;
        }

        private void PlayerInputListener_OnMovePerformed(object sender, PlayerInputListener.MovePerformedEventArgs e)
        {
            Vector2 movementVector = e.movementVector;
            avatarController.SetMovementVector(movementVector);
            droneVisualsController.SetNormilazedTiltValue(movementVector);
        }

        private void PlayerInputListener_OnInteractPerformed(object sender, System.EventArgs e)
        {
            courierController.PickupItem();
        }
    }
}
