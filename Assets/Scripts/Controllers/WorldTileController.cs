using System;
using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class WorldTileController : MonoBehaviour
    {
        [Header("Dependancies")]
        [SerializeField]
        private ReactiveFloat worldMovementSpeed;
        [SerializeField]
        private ReactiveFloat worldMovementMultiplier;

        [Space]
        [Header("Pickup Items Configs")]
        [SerializeField]
        private bool visualizeSpawnPoints = false;
        [SerializeField]
        private List<Vector2> possibleSpawnPoints;

        private bool worldBoundaryEventWasSent = false;
        public event EventHandler OnEnterWorldsEndBoundary;

        private void Update()
        {
            float movementSpeed = worldMovementSpeed.GetValue() * worldMovementMultiplier.GetValue();
            transform.position += -Vector3.forward * Time.deltaTime * movementSpeed;
        }

        public void Initialize(List<PickupItemScriptableObject> pickupItemsToSpawn)
        {
            for (int i = 0; i < 10; i++)
            {
                int randomSpawnPointIndex = UnityEngine.Random.Range(0, possibleSpawnPoints.Count - 1);
                Vector3 spawnPosition = TranslateSpawnPointToLocalSpace(possibleSpawnPoints[randomSpawnPointIndex]);

                Instantiate(
                    SelectRandomPickupItem(pickupItemsToSpawn).prefab,
                    spawnPosition,
                    Quaternion.identity,
                    transform
                );
            }
        }

        private PickupItemScriptableObject SelectRandomPickupItem(List<PickupItemScriptableObject> pickupItemList)
        {
            int randomItemIndex = UnityEngine.Random.Range(0, pickupItemList.Count);
            Debug.LogFormat("Index: {0} of {1}", randomItemIndex, pickupItemList.Count);
            return pickupItemList[randomItemIndex];
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag(
                    GameTags.WorldsEnd.ToString()
                ) || worldBoundaryEventWasSent)
                return;

            Debug.Log("Wiw");

            worldBoundaryEventWasSent = true;
            OnEnterWorldsEndBoundary?.Invoke(this, EventArgs.Empty);
        }

        private void OnDrawGizmos()
        {
            if (visualizeSpawnPoints)
            {
                foreach (Vector2 spawnPointVector in possibleSpawnPoints)
                {
                    Gizmos.DrawSphere(TranslateSpawnPointToLocalSpace(spawnPointVector), .2f);
                }
            }
        }

        private Vector3 TranslateSpawnPointToLocalSpace(Vector2 spawnPoint)
        {
            Vector3 transformedSpawnPoint = new Vector3(
                spawnPoint.x,
                0,
                spawnPoint.y
            );

            return transformedSpawnPoint + transform.position;
        }
    }
}
