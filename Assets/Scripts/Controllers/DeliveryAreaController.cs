using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class DeliveryAreaController : MonoBehaviour
    {
        [SerializeField]
        private ItemPickupGameEvent packagePickedupGameEvent;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<PickupItemController>(out PickupItemController pickupItemController))
                return;

            packagePickedupGameEvent.Invoke(this, pickupItemController.scriptableObject);
            Destroy(other.gameObject);
        }
    }
}
