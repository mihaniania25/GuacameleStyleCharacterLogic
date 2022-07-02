using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class Hero : StateMachine
    {
        public HeroConfig Config;
        public Animator Animator;
        public Rigidbody2D Rigidbody;
        public HeroPhysics Physics;

        public HeroModel Model { get; private set; }
        public HeroMover Mover { get; private set; }
        public HeroCore Core { get; private set; }

        private void Awake()
        {
            InitModel();
            Mover = new HeroMover(this);
            Physics.Setup(this);
            Physics.SetMode(HeroPhysicsModeType.Default);
            Core = new HeroCore(this);

            SetState(new RunState(this));
        }

        private void InitModel()
        {
            Model = new HeroModel
            {
                JumpsCount = 0,
                MaxJumpsCount = 2
            };
        }

        public void TryTakeHit(Vector3 force)
        {
            _state?.TryTakeHit(force);
        }
    }
}