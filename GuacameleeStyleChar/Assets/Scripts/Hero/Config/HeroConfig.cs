using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "Hero/Config")]
    public class HeroConfig :ScriptableObject
    {
        public float MoveSpeed = 0.3f;
        public float JumpVelocity = 0.5f;
        public float MaxJumpVelocityDuration = 0.8f;
    }
}
