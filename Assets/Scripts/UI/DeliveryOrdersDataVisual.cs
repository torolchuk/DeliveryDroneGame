using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DeliveryDroneGame.Utils;

namespace DeliveryDroneGame
{
    public class DeliveryOrdersDataVisual : MonoBehaviour
    {
        [SerializeField]
        private ReactivePickupItemList deliveryOrdersList;
        [SerializeField]
        private Transform deliveryItemUIIconPrefab;

        private void Awake()
        {
            deliveryOrdersList.Subscribe(HandleDeliveryOrderUpdate);
        }

        private void HandleDeliveryOrderUpdate()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            Debug.Log(deliveryOrdersList.GetValue());
            foreach (PickupItemScriptableObject pickupItem in deliveryOrdersList.GetValue())
            {
                Transform newIconTransform = Instantiate(deliveryItemUIIconPrefab, transform);
                newIconTransform.GetComponent<ImageDisplayUIController>().SetSprite(pickupItem.uiIcon);
            }
        }
    }
}
