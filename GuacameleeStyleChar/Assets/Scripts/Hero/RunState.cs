using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class RunState : State
    {
        public RunState(Hero hero) : base(hero)
        {

        }

        public override void Start()
        {
            Model.JumpsCount = 0;
            Model.IsGrounded.Subscribe(OnGroundStateChanged, false);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded == false)
            {
                Model.JumpsCount++;
                Hero.SetState(new FlyState(Hero));
            }
        }

        public override void Update()
        {
            if (ControlReader.Jump && Model.JumpsCount < Model.MaxJumpsCount)
                Hero.SetState(new JumpState(Hero));
            else if (ControlReader.MoveRight)
            {
                Mover.MoveRight();
                Animator.Play(HeroAnimParams.MOVE, 0);
            }
            else if (ControlReader.MoveLeft)
            { 
                Mover.MoveLeft();
                Animator.Play(HeroAnimParams.MOVE, 0);
            }
            else
            {
                Mover.Idle();
                Animator.Play(HeroAnimParams.IDLE, 0);
            }
        }

        public override void Dispose()
        {
            Model.IsGrounded.Unsubscribe(OnGroundStateChanged);
        }
    }
}