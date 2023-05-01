using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class GameStateSoundController : MonoBehaviour
    {
        public enum SoundType
        {
            DeliveryPerfect,
            DeliveryNotPerfect,
            DeliveryFailed,
            FuelRestored
        }

        [SerializeField]
        private GameManager gameManager;
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip deliveryPerfectSound;
        [SerializeField]
        private AudioClip deliveryNotPerfectSound;
        [SerializeField]
        private AudioClip deliveryFailedSound;
        [SerializeField]
        private AudioClip fuelRestoredSound;

        private void Awake()
        {
            gameManager.GameStateSoundTrigger += GameManager_GameStateSoundTrigger;
        }

        private void OnDestroy()
        {
            gameManager.GameStateSoundTrigger -= GameManager_GameStateSoundTrigger;
        }

        private void GameManager_GameStateSoundTrigger(object sender, SoundType soundType)
        {
            audioSource.clip = GetAudioClipBySoundType(soundType);
            audioSource.Play();
        }

        private AudioClip GetAudioClipBySoundType(SoundType soundType)
        {
            switch (soundType)
            {
                case SoundType.DeliveryPerfect:
                    return deliveryPerfectSound;
                case SoundType.DeliveryNotPerfect:
                    return deliveryNotPerfectSound;
                case SoundType.DeliveryFailed:
                    return deliveryFailedSound;
                case SoundType.FuelRestored:
                    return fuelRestoredSound;
                default:
                    return null;
            }
        }
    }
}
