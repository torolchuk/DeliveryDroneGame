using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class TruckController : MonoBehaviour
    {
        private void Update()
        {
            float xOffset =
                Mathf.Sin(Time.time) +
                Mathf.Sin(Time.time * 1.5f) * .2f +
                Mathf.Sin(Time.time * .75f) * 2f;
            transform.position = new Vector3(
                xOffset,
                0,
                0
            );
        }
    }
}
