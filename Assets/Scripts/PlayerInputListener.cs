using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DeliveryDroneGame
{
    public class PlayerInputListener : MonoBehaviour
    {
        private @MainInputActionMap mainInputActionMap;

        public event EventHandler<MovePerformedEventArgs> OnMovePerformed;
        public class MovePerformedEventArgs
        {
            public Vector2 movementVector;
        }

        public event EventHandler OnInteractPerformed;

        void Awake()
        {
            mainInputActionMap = new @MainInputActionMap();
            mainInputActionMap.Gameplay.Enable();

            mainInputActionMap.Gameplay.Move.started += HandleMovePerformed;
            mainInputActionMap.Gameplay.Move.performed += HandleMovePerformed;
            mainInputActionMap.Gameplay.Move.canceled += HandleMovePerformed;

            mainInputActionMap.Gameplay.Interact.performed += HandleInteractPerformed;
        }

        private void HandleMovePerformed(InputAction.CallbackContext callbackContext)
        {
            Vector2 movementVector = callbackContext.ReadValue<Vector2>();
            OnMovePerformed?.Invoke(this, new MovePerformedEventArgs
            {
                movementVector = movementVector
            });
        }

        private void HandleInteractPerformed(InputAction.CallbackContext obj)
        {
            OnInteractPerformed?.Invoke(this, EventArgs.Empty);
        }
    }
}
