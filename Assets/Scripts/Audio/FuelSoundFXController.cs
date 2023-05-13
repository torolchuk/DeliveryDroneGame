using System;
using System.Collections;
using System.Collections.Generic;
using DeliveryDroneGame.Utils;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class FuelSoundFXController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource audioSource;
        [SerializeField]
        private ReactiveFloat fuelCapacity;
        [SerializeField]
        private float threshold;
        [SerializeField]
        private float minVolume;
        [SerializeField]
        private float maxVolume;

        private enum State
        {
            Idle,
            Playing
        }
        private State state;

        private void Awake()
        {
            fuelCapacity.Subscribe(HandleFuelCapacityUpdate);
        }

        private void OnDestroy()
        {
            fuelCapacity.Unsubscribe(HandleFuelCapacityUpdate);
        }

        private void HandleFuelCapacityUpdate()
        {
            float currentValue = fuelCapacity.GetValue();
            switch (state)
            {
                case State.Idle:
                    IdleStateUpdate(currentValue);
                    break;
                case State.Playing:
                    PlayingStateUpdate(currentValue);
                    break;
                default:
                    return;
            }
        }

        private void PlayingStateUpdate(float currentValue)
        {
            if (currentValue > threshold)
            {
                state = State.Idle;
                audioSource.Stop();
            }
            else
            {
                audioSource.volume = CalculateCurrentVolume(currentValue);
            }
        }

        private void IdleStateUpdate(float currentValue)
        {
            if (currentValue > threshold)
                return;

            state = State.Playing;
            audioSource.volume = CalculateCurrentVolume(currentValue);
            audioSource.Play();

        }

        private float CalculateCurrentVolume(float fuelCapacity)
        {
            float normilazedFuelCapacity = Mathf.Min(fuelCapacity / threshold, 1);
            float volumeDelta = maxVolume - minVolume;
            return volumeDelta - (volumeDelta * normilazedFuelCapacity) + minVolume;
        }
    }
}
