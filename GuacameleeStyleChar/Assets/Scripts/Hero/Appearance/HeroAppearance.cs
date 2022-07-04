using System;
using System.Collections.Generic;
using UnityEngine;
using GuacameleeStyleChar.Fx;

namespace GuacameleeStyleChar.Character
{
    [Serializable]
    public class HeroAppearance
    {
        [SerializeField] private Material _material;
        [SerializeField] private List<SpriteRenderer> _renderers;

        private Blicker _blicker;

        public void Setup(HeroAppearanceSettings settings)
        {
            Material renderersMaterial = new Material(_material);
            _renderers.ForEach(r => r.material = renderersMaterial);

            _blicker = new Blicker(renderersMaterial, settings.DamagedBlickData);
        }

        public void DoBlicking()
        {
            _blicker.DoBlicking();
        }
    }
}
