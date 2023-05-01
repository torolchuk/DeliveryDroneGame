using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class DroneVisualsController : MonoBehaviour
    {
        private const float ROTATION_SPEED = 1440f;
        [SerializeField]
        private float maxTiltAngle = 30f;
        [SerializeField]
        [Range(0f, 1f)]
        private float tiltingInertia = .1f;

        [SerializeField]
        private CourierController courierController;
        [SerializeField]
        private SpriteRenderer pickupItemIconRenderer;

        [SerializeField]
        private List<Transform> motorList;
        [SerializeField]
        private List<Transform> rotorList;

        private Vector2 tiltVector;
        private Vector2 targetTiltVector;

        private void Awake()
        {
            courierController.OnPickupItemUpdateEvent += CourierController_OnPickupItemUpdateEvent;
        }

        private void CourierController_OnPickupItemUpdateEvent(object sender, System.EventArgs e)
        {
            CourierController courierController = sender as CourierController;
            PickupItemScriptableObject pickupItemScriptableObject = courierController.GetCurrentPickupItemInfo();

            pickupItemIconRenderer.sprite = pickupItemScriptableObject?.uiIcon;
        }

        public void SetNormilazedTiltValue(Vector2 tiltVector)
        {
            targetTiltVector = tiltVector;
        }

        private void Update()
        {
            tiltVector = Vector2.Lerp(tiltVector, targetTiltVector, tiltingInertia);
            UpdateTilting();
            UpdateRotors();
        }

        private void UpdateTilting()
        {
            Vector3 tiltingEularAngle = new Vector3(
                tiltVector.y * maxTiltAngle,
                0,
                -tiltVector.x * maxTiltAngle
            );
            transform.localEulerAngles = tiltingEularAngle * .5f;

            Vector3 motorTiltValue = new Vector3(
                tiltVector.y * maxTiltAngle,
                -tiltVector.x * maxTiltAngle,
                0
            );

            Debug.Log("_______");
            Debug.Log(motorTiltValue);
            foreach (Transform motor in motorList)
            {
                motor.localEulerAngles = motorTiltValue;
                Debug.Log(motor.eulerAngles);
            }
        }

        private void UpdateRotors()
        {
            foreach (Transform rotor in rotorList)
            {
                rotor.Rotate(Vector3.forward * ROTATION_SPEED * Time.deltaTime);
            }
        }
    }
}
