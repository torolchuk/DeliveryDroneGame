using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DeliveryDroneGame
{
    public class AbstractGameEvent<EventArgsType> : ScriptableObject
    {
        public event EventHandler<EventArgsType> eventHandler;

        public void Invoke(object sender, EventArgsType eventArgs)
        {
            eventHandler?.Invoke(sender, eventArgs);
        }
    }
}
