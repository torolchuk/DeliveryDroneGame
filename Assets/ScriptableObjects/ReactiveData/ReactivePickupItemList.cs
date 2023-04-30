using System.Collections.Generic;
using UnityEngine;
using DeliveryDroneGame.Utils;

namespace DeliveryDroneGame.Utils
{
    [CreateAssetMenu(
        fileName = "NewReactivePickupItemList",
        menuName = "ScriptableObjects/ReactiveData/PickupItemList"
    )]
    public class ReactivePickupItemList : AbstractComplexReactiveData<List<PickupItemScriptableObject>>
    {
    }
}

