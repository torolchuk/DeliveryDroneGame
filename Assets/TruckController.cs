using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class TruckController : MonoBehaviour
    {
        [SerializeField]
        private ReactiveFloat gameSpeedMultiplier;

        private void Update()
        {
            float xOffset =
                Mathf.Sin(Time.time) +
                Mathf.Sin(Time.time * 1.5f) * .2f +
                Mathf.Sin(Time.time * .75f) * 2f;
            float truckMovementMultiplier =
                Mathf.Clamp(
                    gameSpeedMultiplier.GetValue() - 1,
                    0f,
                    0.2f
                ) * 5;

            transform.position = new Vector3(
                xOffset * truckMovementMultiplier,
                0,
                0
            );
        }
    }
}
