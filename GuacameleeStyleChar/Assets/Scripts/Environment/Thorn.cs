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

        private float _forceX;
        private float _forceY;

        private void Awake()
        {
            _forceX = Mathf.Cos(_hitAngle * Mathf.Deg2Rad) * _hitForce;
            _forceY = Mathf.Sin(_hitAngle * Mathf.Deg2Rad) * _hitForce;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == GameTags.PLAYER)
            {
                HeroBody heroBody = collision.gameObject.GetComponent<HeroBody>();
                Hero hero = heroBody.Hero;

                Vector3 forceVector = new Vector3(_forceX, _forceY);
                Vector3 vectorToHero = hero.gameObject.transform.position - transform.position;

                if (vectorToHero.x <= 0)
                    forceVector.x *= -1.0f;

                bool isHitted = hero.TryTakeHit(forceVector);

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