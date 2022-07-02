using UnityEngine;
using GuacameleeStyleChar.Utility;

namespace GuacameleeStyleChar.Character
{
    public class HeroModel
    {
        public int JumpsCount = 0;
        public int MaxJumpsCount;
        public Vector3 TakenDamageForce;

        public PropagationField<bool> IsGrounded { get; private set; }

        public HeroModel()
        {
            IsGrounded = new PropagationField<bool>();
        }
    }
}
