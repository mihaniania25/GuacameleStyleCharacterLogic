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
            Model.JumpsCount = 0;
            GroundDetector.IsGrounded.Subscribe(OnGroundStateChanged, false);
        }

        private void OnGroundStateChanged(bool isGrounded)
        {
            if (isGrounded == false)
            {
                Model.JumpsCount++;
                _character.SetState(new FlyState(_character));
            }
        }

        public override void Update()
        {
            if (ControlReader.Jump && Model.JumpsCount < Model.MaxJumpsCount)
                _character.SetState(new JumpState(_character));
            else if (ControlReader.MoveRight)
            {
                Mover.MoveRight();
                Animator.Play(CharAnimStates.MOVE, 0);
            }
            else if (ControlReader.MoveLeft)
            { 
                Mover.MoveLeft();
                Animator.Play(CharAnimStates.MOVE, 0);
            }
            else
            {
                Mover.Idle();
                Animator.Play(CharAnimStates.IDLE, 0);
            }
        }

        public override void Dispose()
        {
            GroundDetector.IsGrounded.Unsubscribe(OnGroundStateChanged);
        }
    }
}