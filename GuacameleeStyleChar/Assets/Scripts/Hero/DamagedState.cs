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

        public override bool TryTakeHit(Vector3 force)
        {
            return false;
        }

        public override void Start()
        {
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.simulated = false;
            Animator.speed = 0.0f;
            _beforeFallTask = new Task(TakeHitCoro());
        }

        private IEnumerator TakeHitCoro()
        {
            yield return new WaitForSeconds(Config.TakingDmgDurationSec);

            Appearance.DoBlicking();

            Physics.SetMode(HeroPhysicsModeType.Falling);
            Animator.Play(HeroAnimParams.FALL, 0);
            Animator.speed = 1;
            Rigidbody.simulated = true;
            Rigidbody.AddForce(Model.TakenDamageForce);

            yield return WaitUntilFallDown();

            Model.IsGrounded.Value = false;
            Model.IsGrounded.Subscribe(OnGroundedStateChanged, false);
        }

        private IEnumerator WaitUntilFallDown()
        {
            float gravityForce_Y = Rigidbody.mass * Rigidbody.gravityScale * -Physics2D.gravity.y;
            float acc_Y = (Model.TakenDamageForce.y - gravityForce_Y) / Rigidbody.mass;
            float vel0_Y = acc_Y * Time.fixedDeltaTime;

            float raiseTime = vel0_Y / (Rigidbody.gravityScale * -Physics2D.gravity.y);

            yield return new WaitForSeconds(raiseTime);
        }

        private void OnGroundedStateChanged(bool isGrounded)
        {
            if (isGrounded)
            {
                Model.IsGrounded.Unsubscribe(OnGroundedStateChanged);

                SoundPlayer.PlaySound(Config.SoundSettings.Fall);

                _afterFallTask = new Task(AfterFallCoro());
            }
        }

        private IEnumerator AfterFallCoro()
        {
            yield return new WaitForSeconds(Config.DmgRecoveryDurationSec);

            Physics.SetMode(HeroPhysicsModeType.Default);
            Hero.SetState(new WalkState(Hero));
        }

        public override void Dispose()
        {
            Model.IsGrounded.Unsubscribe(OnGroundedStateChanged);
            _beforeFallTask?.Stop();
            _afterFallTask?.Stop();
        }
    }
}
