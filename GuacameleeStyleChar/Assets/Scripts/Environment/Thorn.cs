using UnityEngine;
using GuacameleeStyleChar.Character;

namespace GuacameleeStyleChar.Level
{
    public class Thorn : MonoBehaviour
    {
        [SerializeField] private float _hitForce;

        [Range(5.0f, 85.0f)]
        [SerializeField] private float _hitAngle = 45.0f;

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

                hero.TryTakeHit(new Vector3(forceX, forceY, 0.0f));
            }
        }
    }
}