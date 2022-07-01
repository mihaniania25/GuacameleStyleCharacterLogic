using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public abstract class State
    {
        protected Character _character;

        public State(Character character)
        {
            _character = character;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void Dispose()
        {

        }
    }
}