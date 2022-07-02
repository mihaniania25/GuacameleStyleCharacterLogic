using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class FlyState : State
    {
        public FlyState(Character character) : base(character)
        {

        }

        public override void Start()
        {
            Animator.Play(CharAnimStates.FLY, 0);
            GroundDetector.IsGrounded.Subscribe(OnGroundedChange);
        }

        public override void Update()
        {
            if (ControlReader.Jump && Model.JumpsCount < Model.MaxJumpsCount)
                _character.SetState(new JumpState(_character));
            else
                Mover.DefaultMoveUpdate();
        }

        private void OnGroundedChange(bool isGrounded)
        {
            if (isGrounded)
            {
                GroundDetector.IsGrounded.Unsubscribe(OnGroundedChange);

                _character.SetState(new RunState(_character));
            }
        }

        public override void Dispose()
        {
            GroundDetector.IsGrounded.Unsubscribe(OnGroundedChange);
        }
    }
}