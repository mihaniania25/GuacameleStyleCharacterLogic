using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class HeroBody : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public Hero Hero => _hero;
    }
}
