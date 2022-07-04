using System.Collections;
using UnityEngine;
using GuacameleeStyleChar.Utility;

namespace GuacameleeStyleChar.Character
{
    public class DamagedState : State
    {
        private Task _beforeFallTask;
        private Task _afterFallTask;

        public DamagedState(Hero hero) : base(hero)
        {

        }

        public override void TryTakeHit(Vector3 force)
        {

        }

        public override void Start()
        {
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.simulated = false;
            Animator.speed = 0.0f;
            _beforeFallTask = new Task(BeforeFallCoro());
        }

        private IEnumerator BeforeFallCoro()
        {
            yield return new WaitForSeconds(Config.TakingDmgDurationSec);

            Appearance.DoBlicking();

            Physics.SetMode(HeroPhysicsModeType.Falling);
            Animator.Play(HeroAnimParams.FALL, 0);
            Animator.speed = 1;
            Rigidbody.simulated = true;
            Rigidbody.AddForce(Model.TakenDamageForce);

            Model.IsGrounded.Subscribe(OnGroundedStateChanged, false);
        }

        private void OnGroundedStateChanged(bool isGrounded)
        {
            if (isGrounded)
            {
                Model.IsGrounded.Unsubscribe(OnGroundedStateChanged);
                _afterFallTask = new Task(AfterFallCoro());
            }
        }

        private IEnumerator AfterFallCoro()
        {
            yield return new WaitForSeconds(Config.DmgRecoveryDurationSec);

            Physics.SetMode(HeroPhysicsModeType.Default);
            Hero.SetState(new RunState(Hero));
        }

        public override void Dispose()
        {
            Model.IsGrounded.Unsubscribe(OnGroundedStateChanged);
            _beforeFallTask?.Stop();
            _afterFallTask?.Stop();
        }
    }
}
