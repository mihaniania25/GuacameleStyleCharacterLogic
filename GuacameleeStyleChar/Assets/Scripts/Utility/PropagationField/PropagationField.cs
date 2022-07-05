using System;
using UnityEngine;

namespace GuacameleeStyleChar.Utility
{
    [Serializable]
    public class PropagationField<T>
    {
        [SerializeField] protected T _value;

        private event Action<T> _handlers;

        public T Value
        {
            get => GetValue();
            set
            {
                SetValue(value);
                _handlers?.Invoke(GetValue());
            }
        }

        protected virtual T GetValue()
        {
            return _value;
        }

        protected virtual void SetValue(T value)
        {
            _value = value;
        }

        public void Subscribe(Action<T> handler, bool propagateImmediately = true)
        {
            _handlers += handler;

            if (propagateImmediately)
                handler?.Invoke(Value);
        }

        public void Unsubscribe(Action<T> handler)
        {
            _handlers -= handler;
        }

        public void ForcePropagate()
        {
            _handlers?.Invoke(Value);
        }

        public void SetValueSilently(T value)
        {
            SetValue(value);
        }
    }
}