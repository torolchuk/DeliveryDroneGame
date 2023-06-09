using System;
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
        [SerializeField]
        private ReactiveFloat fuelCapacity;

        [Header("Game events")]
        [SerializeField]
        private ItemPickupGameEvent itemPickedupGameEvent;
        [SerializeField]
        private EmptyGameEvent fuelEndedGameEvent;
        [SerializeField]
        private EmptyGameEvent pickupItemLostGameEvent;

        [Header("Game configurations")]
        [SerializeField]
        private PickupItemListScriptableObject pickupItemsAllowedToDeliver;

        public event EventHandler<GameStateSoundController.SoundType> GameStateSoundTrigger;

        private void Awake()
        {
            SetInitialGameState();
            itemPickedupGameEvent.eventHandler += HandleItemPickedupGameEvent;
            pickupItemLostGameEvent.eventHandler += HandlePickupItemLostGameEvent;

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

            fuelCapacity.SetValue(
                Mathf.Max(fuelCapacity.GetValue() - (gameSpeedMultiplier.GetValue() - 1f) / 1000f, 0f)
            );

            if (fuelCapacity.GetValue() <= 0f)
            {
                fuelEndedGameEvent.Invoke(this, EventArgs.Empty);
                gameSpeedMultiplier.SetValue(0f);
                Loader.Load(Loader.Scene.GameOver);
            }
        }

        private void SetInitialGameState()
        {
            gameSpeedMultiplier.SetValue(1f);
            comboMultiplier.SetValue(1f);
            fuelCapacity.SetValue(1f);
            score.SetValue(0);
        }

        private void HandleItemPickedupGameEvent(object sender, PickupItemScriptableObject e)
        {
            if (e.pickupItemType == PickupItemType.Fuel)
            {
                fuelCapacity.SetValue(Mathf.Clamp(
                    fuelCapacity.GetValue() + .2f,
                    0, 1
                ));
                GameStateSoundTrigger.Invoke(this, GameStateSoundController.SoundType.FuelRestored);

                return;
            }

            List<PickupItemScriptableObject> currentDeliveryOrders =
                new List<PickupItemScriptableObject>(deliveryOrders.GetValue());

            for (int i = 0; i < currentDeliveryOrders.Count; i++)
            {
                if (currentDeliveryOrders[i].pickupItemType == e.pickupItemType)
                {
                    float newComboMultiplier = i != 0 ? 1 : comboMultiplier.GetValue() + COMBO_MULTIPLIER_STEP;
                    comboMultiplier.SetValue(newComboMultiplier);
                    float scoreWin = SCORE_PER_DELIVERY * comboMultiplier.GetValue();
                    score.SetValue(score.GetValue() + (int)scoreWin);

                    currentDeliveryOrders.Remove(currentDeliveryOrders[i]);
                    currentDeliveryOrders.Add(pickupItemsAllowedToDeliver
                        .pickupItems[UnityEngine.Random.Range(0, pickupItemsAllowedToDeliver.pickupItems.Count)]);

                    deliveryOrders.SetValue(currentDeliveryOrders);
                    GameStateSoundTrigger.Invoke(this, i == 0 ? GameStateSoundController.SoundType.DeliveryPerfect : GameStateSoundController.SoundType.DeliveryNotPerfect);
                    return;
                }
            }

            GameStateSoundTrigger.Invoke(this, GameStateSoundController.SoundType.DeliveryFailed);

            comboMultiplier.SetValue(1);
        }

        private void HandlePickupItemLostGameEvent(object sender, object e)
        {
            comboMultiplier.SetValue(0f);
            GameStateSoundTrigger.Invoke(this, GameStateSoundController.SoundType.DeliveryFailed);
        }
    }
}
