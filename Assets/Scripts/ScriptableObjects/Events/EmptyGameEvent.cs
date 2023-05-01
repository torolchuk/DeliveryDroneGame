using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    [CreateAssetMenu(
        fileName = "NewEmptyGameEvent",
        menuName = "ScriptableObjects/GameEvents/Empty"
    )]
    public class EmptyGameEvent : AbstractGameEvent<object>
    {

    }
}
