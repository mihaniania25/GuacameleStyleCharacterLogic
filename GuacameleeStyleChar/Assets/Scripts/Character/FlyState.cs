using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class FlyState : State
    {
        private bool _isMoving;

        public FlyState(Character character) : base(character)
        {

        }

        public override void Start()
        {
            _character.Animator.Play(CharAnimStates.FLY, 0);
            _character.GroundDetector.IsGrounded.Subscribe(OnGroundedChange);
        }

        public override void Update()
        {
            _character.Mover.DefaultMoveUpdate();

            _isMoving = ControlReader.MoveRight || ControlReader.MoveLeft;
        }

        private void OnGroundedChange(bool isGrounded)
        {
            if (isGrounded)
            {
                _character.GroundDetector.IsGrounded.Unsubscribe(OnGroundedChange);

                if (_isMoving)
                    _character.SetState(new RunState(_character));
                else
                    _character.SetState(new IdleState(_character));
            }
        }
    }
}