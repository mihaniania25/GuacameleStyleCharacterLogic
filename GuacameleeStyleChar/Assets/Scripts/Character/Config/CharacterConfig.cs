using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "Character/Config")]
    public class CharacterConfig :ScriptableObject
    {
        public float MoveSpeed = 0.3f;
        public float JumpVelocity = 0.5f;
        public float MaxJumpVelocityDuration = 0.8f;
    }
}
