using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class Hero : StateMachine
    {
        public HeroConfig Config;
        public Animator Animator;
        public Rigidbody2D Rigidbody;
        public HeroAppearance Appearance;
        public HeroPhysics Physics;
        public HeroSoundPlayer SoundPlayer;

        public HeroModel Model { get; private set; }
        public HeroMover Mover { get; private set; }
        public HeroCore Core { get; private set; }

        private void Awake()
        {
            Setup();
            SetState(new IdleState(this));
        }

        private void Setup()
        {
            InitModel();

            Mover = new HeroMover(this);

            Physics.Setup(this);
            Physics.SetMode(HeroPhysicsModeType.Default);

            Appearance.Setup(Config.AppearanceSettings);

            Core = new HeroCore(this);
        }

        private void InitModel()
        {
            Model = new HeroModel
            {
                JumpsCount = 0,
                MaxJumpsCount = 2
            };
        }

        public bool TryTakeHit(Vector3 force)
        {
            if (_state != null)
                return _state.TryTakeHit(force);
            return false;
        }
    }
}