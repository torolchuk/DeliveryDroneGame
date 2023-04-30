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

        [Header("Game events")]
        [SerializeField]
        private ItemPickupGameEvent itemPickedupGameEvent;

        private void Awake()
        {
            SetInitialGameState();
            itemPickedupGameEvent.eventHandler += ItemPickedupGameEvent_eventHandler;
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
