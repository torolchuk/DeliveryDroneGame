using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DeliveryDroneGame
{
    [CreateAssetMenu(
        fileName = "PickupItemScriptableObject ",
        menuName = "ScriptableObjects/PickupItem"
    )]
    public class PickupItemScriptableObject : ScriptableObject
    {
        public GameObject prefab;
        public PickupItemType pickupItemType;
        public Sprite uiIcon;
    }
}
