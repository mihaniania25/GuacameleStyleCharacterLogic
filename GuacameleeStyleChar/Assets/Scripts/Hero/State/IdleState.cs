using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class IdleState : DefaultGroundState
    {
        public IdleState(Hero hero) : base(hero)
        {

        }

        public override void Start()
        {
            base.Start();

            Mover.Idle();
            Animator.Play(HeroAnimParams.IDLE, 0);
        }

        public override void Update()
        {
            if (ControlReader.Jump && Model.JumpsCount < Model.MaxJumpsCount)
                Hero.SetState(new JumpState(Hero));
            else if (ControlReader.MoveRight || ControlReader.MoveLeft)
                Hero.SetState(new WalkState(Hero));
        }
    }
}
