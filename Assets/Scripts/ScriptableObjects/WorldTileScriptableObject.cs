using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    [CreateAssetMenu(
        fileName = "WorldTileScriptableObject",
        menuName = "ScriptableObjects/WorldTileScriptableObject"
    )]
    public class WorldTileScriptableObject : ScriptableObject
    {
        public GameObject prefab;
    }
}
