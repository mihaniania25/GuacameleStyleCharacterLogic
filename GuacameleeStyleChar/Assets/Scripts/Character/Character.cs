using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class Character : StateMachine
    {
        public CharacterConfig Config;
        public Animator Animator;
        public Rigidbody2D Rigidbody;
        public GroundDetector GroundDetector;

        public CharacterModel Model { get; private set; }
        public CharacterMover Mover { get; private set; }

        private void Awake()
        {
            InitModel();
            Mover = new CharacterMover(this);

            SetState(new RunState(this));
        }

        private void InitModel()
        {
            Model = new CharacterModel
            {
                JumpsCount = 0,
                MaxJumpsCount = 2
            };
        }
    }
}