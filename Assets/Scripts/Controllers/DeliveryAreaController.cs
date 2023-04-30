using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class DeliveryAreaController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PickupItemController>(out PickupItemController pickupItemController))
                return;

            Destroy(other.gameObject);
        }
    }
}
