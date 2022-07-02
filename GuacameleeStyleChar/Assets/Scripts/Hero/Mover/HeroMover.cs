using UnityEngine;
using GuacameleeStyleChar.Control;

namespace GuacameleeStyleChar.Character
{
    public class HeroMover
    {
        private Hero _hero;

        public HeroMover(Hero character)
        {
            _hero = character;
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
            SetHorizontalVelocity(_hero.Config.MoveSpeed);
            _hero.Animator.SetInteger(HeroAnimParams.DIRECTION, (int)MoveDirectionType.Right);
        }

        public void MoveLeft()
        {
            SetHorizontalVelocity(-_hero.Config.MoveSpeed);
            _hero.Animator.SetInteger(HeroAnimParams.DIRECTION, (int)MoveDirectionType.Left);
        }

        private void SetHorizontalVelocity(float value)
        {
            Vector3 newVelocity = _hero.Rigidbody.velocity;
            newVelocity.x = value;

            _hero.Rigidbody.velocity = newVelocity;
        }
    }
}
