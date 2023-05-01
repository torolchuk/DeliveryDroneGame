using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class ComboDisplayController : MonoBehaviour
    {
        [SerializeField]
        private ReactiveFloat comboMultiplier;

        private void Awake()
        {
            comboMultiplier.Subscribe(HandleComboMultiplierUpdate);

            HandleComboMultiplierUpdate();
        }

        private void HandleComboMultiplierUpdate()
        {
            float currentCombo = comboMultiplier.GetValue();

            bool displayUI = currentCombo > 1;

            gameObject.SetActive(displayUI);
        }

        private void OnDestroy()
        {
            comboMultiplier.Unsubscribe(HandleComboMultiplierUpdate);
        }
    }
}
