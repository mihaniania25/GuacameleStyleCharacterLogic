using System;
using System.Collections.Generic;
using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    [Serializable]
    public class HeroPhysicsMode
    {
        [SerializeField] private HeroPhysicsModeType _type;
        [SerializeField] private GroundDetector _groundDetector;
        [SerializeField] private List<Collider2D> _colliders;

        public HeroPhysicsModeType Type => _type;

        public void Setup(Hero hero)
        {
            _groundDetector.Setup(hero);
            Deactivate();
        }

        public void Activate()
        {
            _colliders.ForEach(c => c.enabled = true);
            _groundDetector.enabled = true;
        }

        public void Deactivate()
        {
            _colliders.ForEach(c => c.enabled = false);
            _groundDetector.enabled = false;
        }
    }
}
