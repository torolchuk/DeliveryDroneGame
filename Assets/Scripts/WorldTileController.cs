using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class WorldTileController : MonoBehaviour
    {
        [SerializeField]
        private ReactiveFloat worldMovementSpeed;
        [SerializeField]
        private ReactiveFloat worldMovementMultiplier;

        void Update()
        {
            float movementSpeed = worldMovementSpeed.GetValue() * worldMovementMultiplier.GetValue();
            transform.position += -Vector3.forward * Time.deltaTime * movementSpeed;
        }
    }
}
