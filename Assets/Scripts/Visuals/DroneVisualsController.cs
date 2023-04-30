using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class DroneVisualsController : MonoBehaviour
    {
        [SerializeField]
        private float maxTiltAngle = 30f;
        [SerializeField]
        [Range(0f, 1f)]
        private float tiltingInertia = .1f;
        [SerializeField]
        private Vector3 motorRotationOffset;

        [SerializeField]
        private List<Transform> motorList;

        private Vector2 tiltVector;
        private Vector2 targetTiltVector;

        public void SetNormilazedTiltValue(Vector2 tiltVector)
        {
            targetTiltVector = tiltVector;
        }

        private void Update()
        {
            tiltVector = Vector2.Lerp(tiltVector, targetTiltVector, tiltingInertia);
            UpdateTilting();
        }

        private void UpdateTilting()
        {
            Vector3 tiltingEularAngle = new Vector3(
                tiltVector.y * maxTiltAngle,
                0,
                -tiltVector.x * maxTiltAngle
            );

            transform.eulerAngles = tiltingEularAngle * .5f;

            foreach (Transform motor in motorList)
            {
                motor.eulerAngles = tiltingEularAngle + motorRotationOffset;
            }
        }
    }
}
