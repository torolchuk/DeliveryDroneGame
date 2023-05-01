using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DeliveryDroneGame
{
    public class ProgressBarUIDisplay : MonoBehaviour
    {
        [SerializeField]
        private ReactiveFloat reactiveFloat;
        [SerializeField]
        private Image image;

        [SerializeField]
        private float normalizationBottom = 0f;
        [SerializeField]
        private float normalizationTop = 1f;

        private void Awake()
        {
            reactiveFloat.Subscribe(HandleReactiveFloatUpdate);
        }

        private void HandleReactiveFloatUpdate()
        {
            float currentValue = reactiveFloat.GetValue();
            float clampedValue = Mathf.Clamp(currentValue, normalizationBottom, normalizationTop);
            float normalizedValue = (clampedValue - normalizationBottom) / (normalizationTop - normalizationBottom);

            image.fillAmount = normalizedValue;
        }
    }
}
