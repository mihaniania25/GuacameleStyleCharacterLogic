using UnityEngine;
using GuacameleeStyleChar.Utility;

namespace GuacameleeStyleChar.Character
{
    public class GroundDetector : MonoBehaviour
    {
        private PropagationField<bool> _isGrounded;

        public void Setup(Hero hero)
        {
            _isGrounded = hero.Model.IsGrounded;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == GameTags.GROUND)
                _isGrounded.Value = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == GameTags.GROUND && !_isGrounded.Value)
                _isGrounded.Value = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == GameTags.GROUND)
                _isGrounded.Value = false;
        }
    }
}
