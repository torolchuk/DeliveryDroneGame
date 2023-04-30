using System;
using UnityEngine;

namespace DeliveryDroneGame.Utils
{
    public abstract class AbstractComplexReactiveData<ValueType>
    : ScriptableObject,
        IReactiveValue<ValueType>,
         ISubscribe
    {
        [SerializeField]
        private ValueType _value;
        private event Action listeners;

        public ValueType GetValue()
        {
            return _value;
        }

        public void SetValue(ValueType value)
        {
            _value = value;
            if (listeners != null)
                listeners();
        }

        public void Subscribe(Action callback)
        {
            listeners += callback;
        }

        public void Unsubscribe(Action callback)
        {
            listeners -= callback;
        }
    }
}
