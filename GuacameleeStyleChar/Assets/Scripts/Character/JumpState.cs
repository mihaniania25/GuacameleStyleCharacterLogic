using UnityEngine;
using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class JumpState : State
    {
        private float _maxJumpTime;
        private bool _isJumping;

        public JumpState(Character character) : base(character)
        {

        }

        public override void Start()
        {
            Model.JumpsCount++;

            if (Model.JumpsCount > 1)
                Animator.SetTrigger(CharAnimStates.FLIP);
            Animator.Play(CharAnimStates.FLY, 0);

            _maxJumpTime = Time.time + Config.MaxJumpVelocityDuration;
        }

        public override void Update()
        {
            Mover.DefaultMoveUpdate();

            _isJumping = ControlReader.JumpHold && Time.time <= _maxJumpTime;

            if (_isJumping)
                SetVerticalVelocity(Config.JumpVelocity);
            else
                _character.SetState(new FlyState(_character));
        }

        private void SetVerticalVelocity(float value)
        {
            Vector3 newVelocity = Rigidbody.velocity;
            newVelocity.y = value;
            Rigidbody.velocity = newVelocity;
        }
    }
}