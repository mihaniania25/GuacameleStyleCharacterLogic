using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class HeroCore
    {
        private Hero _hero;

        public HeroCore(Hero hero)
        {
            _hero = hero;
        }

        public bool TakeHit(Vector3 force)
        {
            _hero.Model.TakenDamageForce = force;

            MoveDirectionType directionType = force.x < 0 ? MoveDirectionType.Right : MoveDirectionType.Left;
            _hero.Animator.SetInteger(HeroAnimParams.DIRECTION, (int)directionType);

            _hero.SetState(new DamagedState(_hero));
            return true;
        }
    }
}
