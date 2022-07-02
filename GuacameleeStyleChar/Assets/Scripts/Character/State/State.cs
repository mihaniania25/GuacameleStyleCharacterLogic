using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public abstract class State
    {
        protected Character _character;

        protected Animator Animator => _character.Animator;
        protected CharacterModel Model => _character.Model;
        protected Rigidbody2D Rigidbody => _character.Rigidbody;
        protected GroundDetector GroundDetector => _character.GroundDetector;
        protected CharacterMover Mover => _character.Mover;
        protected CharacterConfig Config => _character.Config;

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