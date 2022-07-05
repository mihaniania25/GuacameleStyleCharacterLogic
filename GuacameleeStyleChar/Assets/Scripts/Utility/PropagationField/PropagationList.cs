using System;
using System.Collections.Generic;

namespace GuacameleeStyleChar.Utility
{
    [Serializable]
    public class PropagationList<T> : PropagationField<List<T>>
    {
        public void Add(T value, bool propagate = true)
        {
            GetValue().Add(value);

            if (propagate)
                ForcePropagate();
        }

        public void Remove(T value, bool propagate = true)
        {
            GetValue().Remove(value);

            if (propagate)
                ForcePropagate();
        }

        public void Clear(bool propagate = true)
        {
            GetValue().Clear();

            if (propagate)
                ForcePropagate();
        }
    }
}