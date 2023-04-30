using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace DeliveryDroneGame
{
    [CreateAssetMenu(
        fileName = "NewPickupItemListScriptableObject",
        menuName = "ScriptableObjects/PickupItemList"
    )]
    public class PickupItemListScriptableObject : ScriptableObject
    {
        public List<PickupItemScriptableObject> pickupItems;
    }
}
