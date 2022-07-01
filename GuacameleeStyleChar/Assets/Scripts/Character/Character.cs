using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class Character : StateMachine
    {
        public CharacterConfig Config;
        public Animator Animator;
        public Rigidbody2D Rigidbody;
        public GroundDetector GroundDetector;

        public CharacterMover Mover { get; private set; }

        private void Awake()
        {
            Mover = new CharacterMover(this);
            SetState(new IdleState(this));
        }
    }
}