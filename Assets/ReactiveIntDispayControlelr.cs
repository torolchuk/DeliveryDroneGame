using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;
using TMPro;

namespace DeliveryDroneGame
{
    public class ReactiveIntDispayControlelr : MonoBehaviour
    {
        [SerializeField]
        private ReactiveInteger reactiveInteger;
        [SerializeField]
        private TextMeshProUGUI textMeshPro;
        [SerializeField]
        private string prefix;
        [SerializeField]
        private string suffix;

        private void Awake()
        {
            reactiveInteger.Subscribe(HandleReactiveValueChange);
        }

        private void HandleReactiveValueChange()
        {
            textMeshPro.text =
                prefix +
                reactiveInteger.GetValue().ToString() +
                suffix;
        }
    }
}
