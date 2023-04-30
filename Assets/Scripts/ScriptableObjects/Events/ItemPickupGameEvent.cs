using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    [CreateAssetMenu(
        fileName = "NewItemPickupGameEvent",
        menuName = "ScriptableObjects/GameEvents/ItemPickup"
    )]
    public class ItemPickupGameEvent : AbstractGameEvent<PickupItemScriptableObject>
    {

    }
}
