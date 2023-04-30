using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class GameManager : MonoBehaviour
    {
        [Header("Game state data")]
        [SerializeField]
        private ReactiveFloat gameSpeedMultiplier;
        [SerializeField]
        private ReactiveInteger score;
        [SerializeField]
        private ReactivePickupItemList deliveryOrders;

        [Header("Game events")]
        [SerializeField]
        private ItemPickupGameEvent itemPickedupGameEvent;

        [Header("Game configurations")]
        [SerializeField]
        private PickupItemListScriptableObject pickupItemsAllowedToDeliver;

        private void Awake()
        {
            SetInitialGameState();
            itemPickedupGameEvent.eventHandler += ItemPickedupGameEvent_eventHandler;

            List<PickupItemScriptableObject> newDeliveryList = new List<PickupItemScriptableObject>();
            for (int i = 0; i < 4; i++)
            {
                PickupItemScriptableObject randomPickupItem =
                    pickupItemsAllowedToDeliver
                        .pickupItems[UnityEngine.Random.Range(0, pickupItemsAllowedToDeliver.pickupItems.Count)];

                newDeliveryList.Add(randomPickupItem);
            }

            deliveryOrders.SetValue(
                newDeliveryList
            );
        }

        private void Update()
        {
            gameSpeedMultiplier.SetValue(
                gameSpeedMultiplier.GetValue() + Time.deltaTime / 100
            );
        }

        private void SetInitialGameState()
        {
            gameSpeedMultiplier.SetValue(1f);
            score.SetValue(0);
        }

        private void ItemPickedupGameEvent_eventHandler(object sender, PickupItemScriptableObject e)
        {
            score.SetValue(
                score.GetValue() + 5
            );
        }
    }
}
