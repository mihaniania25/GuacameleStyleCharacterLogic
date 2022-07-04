using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class WalkState : DefaultGroundState
    {
        private const string WALK_SOUND_LABEL = "Walk";

        public WalkState(Hero hero) : base(hero)
        {

        }

        public override void Start()
        {
            base.Start();

            Animator.Play(HeroAnimParams.MOVE, 0);
            SoundPlayer.PlaySound(Config.SoundSettings.Walk, true, WALK_SOUND_LABEL);
        }

        public override void Update()
        {
            if (ControlReader.Jump && Model.JumpsCount < Model.MaxJumpsCount)
                Hero.SetState(new JumpState(Hero));
            else if (ControlReader.MoveRight)
                Mover.MoveRight();
            else if (ControlReader.MoveLeft)
                Mover.MoveLeft();
            else
                Hero.SetState(new IdleState(Hero));
        }

        public override void Dispose()
        {
            base.Dispose();

            SoundPlayer.StopSound(WALK_SOUND_LABEL);
        }
    }
}