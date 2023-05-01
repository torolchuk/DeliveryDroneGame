using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class GameManager : MonoBehaviour
    {
        private const int SCORE_PER_DELIVERY = 100;
        private const float COMBO_MULTIPLIER_STEP = 0.25f;

        [Header("Game state data")]
        [SerializeField]
        private ReactiveFloat gameSpeedMultiplier;
        [SerializeField]
        private ReactiveInteger score;
        [SerializeField]
        private ReactiveFloat comboMultiplier;
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
            itemPickedupGameEvent.eventHandler += HandleItemPickedupGameEvent;

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

        private void HandleItemPickedupGameEvent(object sender, PickupItemScriptableObject e)
        {
            List<PickupItemScriptableObject> currentDeliveryOrders =
                new List<PickupItemScriptableObject>(deliveryOrders.GetValue());

            for (int i = 0; i < currentDeliveryOrders.Count; i++)
            {
                if (currentDeliveryOrders[i].pickupItemType == e.pickupItemType)
                {
                    Debug.LogFormat(
                        "TYPE A: {0}, TYPE B: {1}",
                        currentDeliveryOrders[i].pickupItemType.ToString(),
                        e.pickupItemType.ToString()
                    );
                    float newComboMultiplier = i != 0 ? 1 : comboMultiplier.GetValue() + COMBO_MULTIPLIER_STEP;
                    comboMultiplier.SetValue(newComboMultiplier);
                    float scoreWin = SCORE_PER_DELIVERY * comboMultiplier.GetValue();
                    score.SetValue(score.GetValue() + (int)scoreWin);

                    currentDeliveryOrders.Remove(currentDeliveryOrders[i]);
                    currentDeliveryOrders.Add(pickupItemsAllowedToDeliver
                        .pickupItems[UnityEngine.Random.Range(0, pickupItemsAllowedToDeliver.pickupItems.Count)]);

                    deliveryOrders.SetValue(currentDeliveryOrders);
                    return;
                }
            }

            comboMultiplier.SetValue(1);
        }
    }
}