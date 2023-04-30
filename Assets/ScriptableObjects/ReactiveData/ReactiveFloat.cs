using UnityEngine;
using DeliveryDroneGame.Utils;

namespace DeliveryDroneGame.Utils
{
    [CreateAssetMenu(
        fileName = "ReactiveFloat",
        menuName = "ScriptableObjects/ReactiveData/Float"
    )]
    public class ReactiveFloat : AbstractReactiveData<float>
    {
    }
}
