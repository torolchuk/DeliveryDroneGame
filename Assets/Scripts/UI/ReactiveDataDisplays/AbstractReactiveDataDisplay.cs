using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace DeliveryDroneGame.Utils
{
    public abstract class AbstractReactiveDataDisplay<ReactiveValueType, ValueType> : MonoBehaviour
        where ReactiveValueType : AbstractReactiveData<ValueType>
        where ValueType : struct, IEquatable<ValueType>
    {
        [SerializeField]
        private ReactiveValueType valueRef;
        [SerializeField]
        private string prefix = "";
        [SerializeField]
        private string suffix = "";
        [SerializeField]
        private TextMeshProUGUI textMeshPro;

        private ValueType _valueCache;

        private void Awake()
        {
            valueRef.Subscribe(HandleValueChange);
            HandleValueChange();
        }

        private void Start()
        {
            HandleValueChange();
        }

        void HandleValueChange()
        {
            ValueType updatedValue = valueRef.GetValue();
            _valueCache = updatedValue;

            UpdateText();
        }

        private string ComposeTextToDisplay()
        {
            return prefix + _valueCache.ToString() + suffix;
        }

        private void UpdateText()
        {
            string updatedText = ComposeTextToDisplay();
            textMeshPro.SetText(updatedText);
        }

        private void OnDestroy()
        {
            valueRef.Unsubscribe(HandleValueChange);
        }
    }
}
