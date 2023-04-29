using System;
using UnityEngine;

namespace DeliveryDroneGame.Utils
{
    public interface ISubscribe
    {
        void Subscribe(Action callback);
        void Unsubscribe(Action callback);
    }

    public interface IEmittable
    {
        void Emit();
    }

    public interface IReactiveValue<ValueType>
    {
        ValueType GetValue();
        void SetValue(ValueType value);
    }

    public abstract class AbstractReactiveData<ValueType>
    : ScriptableObject,
        IReactiveValue<ValueType>,
         ISubscribe
        where ValueType : struct
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
