using System;
using UnityEngine;

namespace GuacameleeStyleChar
{
    [Serializable]
    public class SoundData
    {
        public AudioClip Clip;

        [Range(0f, 1f)]
        public float Volume = 1f;
    }
}
