using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    [CreateAssetMenu(
        fileName = "PickupItemScriptableObject ",
        menuName = "ScriptableObjects/PickupItem"
    )]
    public class PickupItemScriptableObject : ScriptableObject
    {
        public GameObject prefab;
    }
}
