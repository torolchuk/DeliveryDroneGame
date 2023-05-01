using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class DroneSoundFXController : MonoBehaviour
    {
        public enum SoundType
        {
            ItemPickup,
            ItemDrop
        }

        [SerializeField]
        private CourierController courierController;

        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip pickupSound;
        [SerializeField]
        private AudioClip dropSound;

        private void Awake()
        {
            courierController.OnPickupItemUpdateEvent += CourierController_OnPickupItemUpdateEvent;
        }

        private void CourierController_OnPickupItemUpdateEvent(object sender, System.EventArgs e)
        {
            AudioClip soundToPlay = (sender as CourierController).GetCurrentPickupItemInfo() != null
                ? pickupSound : dropSound;

            audioSource.clip = soundToPlay;
            audioSource.Play();
        }

        private void OnDestroy()
        {
            courierController.OnPickupItemUpdateEvent -= CourierController_OnPickupItemUpdateEvent;
        }
    }
}
