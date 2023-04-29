using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class WorldController : MonoBehaviour
    {
        [SerializeField]
        private List<WorldTileScriptableObject> worldTileScriptableObjects;

        private List<WorldTileController> activeWorldTiles;

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < 10; i++)
            {
                Instantiate(
                    worldTileScriptableObjects[0].prefab,
                    Vector3.forward * i * 50,
                    Quaternion.identity,
                    transform
                );
            }
        }

        private void Start()
        {

        }
    }
}
