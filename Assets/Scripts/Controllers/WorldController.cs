using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class WorldController : MonoBehaviour
    {
        [SerializeField]
        private List<WorldTileScriptableObject> worldTileScriptableObjects;
        [SerializeField]
        private PickupItemListScriptableObject pickupItemsForSpawn;

        [SerializeField]
        private float tileSpawnPositionOffset = 50;
        [SerializeField]
        private int prepopulateAmount = 2;

        private List<WorldTileController> activeWorldTiles;

        private void Awake()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            for (int i = 0; i < prepopulateAmount; i++)
            {
                SpawnNewWorldTile(
                    worldTileScriptableObjects[0].prefab,
                    i,
                    Vector3.zero
                );
            }
        }

        private void SpawnNewWorldTile(GameObject prefab, int offset, Vector3 vectorOffset)
        {
            Vector3 position = (Vector3.forward * offset * tileSpawnPositionOffset) + vectorOffset;
            GameObject newTileGameObject =
                Instantiate(
                    prefab,
                    position,
                    Quaternion.identity,
                    transform
                );

            WorldTileController newWorldTileController = newTileGameObject.GetComponent<WorldTileController>();
            newWorldTileController.Initialize(pickupItemsForSpawn.pickupItems);

            newWorldTileController.OnEnterWorldsEndBoundary += ChildWorldTileController_OnEnterWorldsEndBoundary;

        }

        private void ChildWorldTileController_OnEnterWorldsEndBoundary(object sender, System.EventArgs e)
        {
            WorldTileController worldTileController = sender as WorldTileController;
            Destroy(worldTileController.gameObject);

            SpawnNewWorldTile(
                worldTileScriptableObjects[0].prefab, prepopulateAmount, worldTileController.transform.position
            );
        }
    }
}
