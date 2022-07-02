using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class FlyState : State
    {
        public FlyState(Hero hero) : base(hero)
        {

        }

        public override void Start()
        {
            Animator.Play(HeroAnimParams.FLY, 0);
            Model.IsGrounded.Subscribe(OnGroundedChange);
        }

        public override void Update()
        {
            if (ControlReader.Jump && Model.JumpsCount < Model.MaxJumpsCount)
                Hero.SetState(new JumpState(Hero));
            else
                Mover.DefaultMoveUpdate();
        }

        private void OnGroundedChange(bool isGrounded)
        {
            if (isGrounded)
            {
                Model.IsGrounded.Unsubscribe(OnGroundedChange);

                Hero.SetState(new RunState(Hero));
            }
        }

        public override void Dispose()
        {
            Model.IsGrounded.Unsubscribe(OnGroundedChange);
        }
    }
}