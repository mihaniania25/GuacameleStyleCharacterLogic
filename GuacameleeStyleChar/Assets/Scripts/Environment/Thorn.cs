using UnityEngine;
using GuacameleeStyleChar.Character;

namespace GuacameleeStyleChar.Level
{
    public class Thorn : MonoBehaviour
    {
        [SerializeField] private float _hitForce;

        [Range(5.0f, 85.0f)]
        [SerializeField] private float _hitAngle = 45.0f;

        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private SoundData _hitSoundData;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == GameTags.PLAYER)
            {
                HeroBody heroBody = collision.gameObject.GetComponent<HeroBody>();
                Hero hero = heroBody.Hero;

                float forceX = Mathf.Cos(_hitAngle * Mathf.Deg2Rad) * _hitForce;
                float forceY = Mathf.Sin(_hitAngle * Mathf.Deg2Rad) * _hitForce;

                Vector3 vectorToHero = hero.gameObject.transform.position - transform.position;

                if (vectorToHero.x <= 0)
                    forceX *= -1.0f;

                bool isHitted = hero.TryTakeHit(new Vector3(forceX, forceY, 0.0f));

                if (isHitted)
                    PlayHitSound();
            }
        }

        private void PlayHitSound()
        {
            _audioSource.clip = _hitSoundData.Clip;
            _audioSource.volume = _hitSoundData.Volume;
            _audioSource.Play();
        }
    }
}