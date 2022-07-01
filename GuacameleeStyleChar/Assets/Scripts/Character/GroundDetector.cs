using UnityEngine;
using GuacameleeStyleChar.Utility;

namespace GuacameleeStyleChar.Character
{
    public class GroundDetector : MonoBehaviour
    {
        public PropagationField<bool> IsGrounded { get; private set; }

        private void Awake()
        {
            IsGrounded = new PropagationField<bool>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == GameTags.GROUND)
                IsGrounded.Value = true;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.tag == GameTags.GROUND && !IsGrounded.Value)
                IsGrounded.Value = true;
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == GameTags.GROUND)
                IsGrounded.Value = false;
        }
    }
}
