using UnityEngine;
using DeliveryDroneGame.Utils;

namespace DeliveryDroneGame.Utils
{
    [CreateAssetMenu(
        fileName = "ReactiveInteger",
        menuName = "ScriptableObjects/ReactiveData/Integer"
    )]
    public class ReactiveInteget : AbstractReactiveData<int>
    {
    }
}

