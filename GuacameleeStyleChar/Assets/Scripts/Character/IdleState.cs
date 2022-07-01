using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class IdleState : State
    {
        public IdleState(Character character) : base(character)
        {

        }

        public override void Start()
        {
            _character.Animator.Play(CharAnimStates.IDLE, 0);
            _character.Mover.Idle();
            _character.GroundDetector.IsGrounded.Subscribe(OnGroundStateChanged, false);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded == false)
                _character.SetState(new FlyState(_character));
        }

        public override void Update()
        {
            if (ControlReader.MoveRight || ControlReader.MoveLeft)
                _character.SetState(new RunState(_character));
            else if (ControlReader.Jump)
                _character.SetState(new JumpState(_character));
        }

        public override void Dispose()
        {
            _character.GroundDetector.IsGrounded.Unsubscribe(OnGroundStateChanged);
        }
    }
}