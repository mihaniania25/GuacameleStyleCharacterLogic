using UnityEngine;
using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class CharacterMover
    {
        private Character _character;

        public CharacterMover(Character character)
        {
            _character = character;
        }

        public void DefaultMoveUpdate()
        {
            if (ControlReader.MoveRight)
                MoveRight();
            else if (ControlReader.MoveLeft)
                MoveLeft();
            else
                Idle();
        }

        public void Idle()
        {
            SetHorizontalVelocity(0.0f);
        }

        public void MoveRight()
        {
            SetHorizontalVelocity(_character.Config.MoveSpeed);
            _character.Animator.SetInteger(CharAnimStates.DIRECTION, (int)MoveDirectionType.Right);
        }

        public void MoveLeft()
        {
            SetHorizontalVelocity(-_character.Config.MoveSpeed);
            _character.Animator.SetInteger(CharAnimStates.DIRECTION, (int)MoveDirectionType.Left);
        }

        private void SetHorizontalVelocity(float value)
        {
            Vector3 newVelocity = _character.Rigidbody.velocity;
            newVelocity.x = value;

            _character.Rigidbody.velocity = newVelocity;
        }
    }
}
