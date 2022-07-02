using System;
using System.Collections.Generic;
using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    [Serializable]
    public class HeroPhysics
    {
        [SerializeField] private List<HeroPhysicsMode> _modes;

        private HeroPhysicsMode _activeMode;

        public void Setup(Hero hero)
        {
            _modes.ForEach(m => m.Setup(hero));
        }

        public void SetMode(HeroPhysicsModeType modeType)
        {
            if (_activeMode != null && _activeMode.Type != modeType)
                _activeMode.Deactivate();

            if (_activeMode == null || _activeMode.Type != modeType)
            {
                _activeMode = _modes.Find(m => m.Type == modeType);
                _activeMode.Activate();
            }
        }
    }
}
