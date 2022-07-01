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
            _character.Animator.Play(CharAnimStates.FLY, 0);
            _maxJumpTime = Time.time + _character.Config.MaxJumpVelocityDuration;
        }

        public override void Update()
        {
            _character.Mover.DefaultMoveUpdate();

            _isJumping = ControlReader.JumpHold && Time.time <= _maxJumpTime;

            if (_isJumping)
                SetVerticalVelocity(_character.Config.JumpVelocity);
            else
                _character.SetState(new FlyState(_character));
        }

        private void SetVerticalVelocity(float value)
        {
            Vector3 newVelocity = _character.Rigidbody.velocity;
            newVelocity.y = value;
            _character.Rigidbody.velocity = newVelocity;
        }
    }
}