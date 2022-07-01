using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class RunState : State
    {
        public RunState(Character character) : base(character)
        {

        }

        public override void Start()
        {
            _character.Animator.Play(CharAnimStates.MOVE, 0);
            _character.GroundDetector.IsGrounded.Subscribe(OnGroundStateChanged, false);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded == false)
                _character.SetState(new FlyState(_character));
        }

        public override void Update()
        {
            if (ControlReader.Jump)
                _character.SetState(new JumpState(_character));
            else if (ControlReader.MoveRight)
                _character.Mover.MoveRight();
            else if (ControlReader.MoveLeft)
                _character.Mover.MoveLeft();
            else
                _character.SetState(new IdleState(_character));
        }

        public override void Dispose()
        {
            _character.GroundDetector.IsGrounded.Unsubscribe(OnGroundStateChanged);
        }
    }
}