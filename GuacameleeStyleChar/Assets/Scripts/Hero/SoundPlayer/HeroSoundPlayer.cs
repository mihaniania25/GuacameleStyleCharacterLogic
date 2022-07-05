using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GuacameleeStyleChar.Utility;

namespace GuacameleeStyleChar.Character
{
    [Serializable]
    public class HeroSoundPlayer
    {
        [SerializeField] private AudioSource _source;

        private List<Task> _destroySourceTasks = new List<Task>();
        private Dictionary<object, AudioSource> _labeledSources = new Dictionary<object, AudioSource>();

        public void PlaySound(SoundData soundData, bool loop = false, object label = null)
        {
            AudioSource source = PickSource(label);

            if (source != null)
            {
                source.loop = loop;
                source.clip = soundData.Clip;
                source.volume = soundData.Volume;

                source.Play();

                if (!loop)
                    _destroySourceTasks.Add(new Task(DestroySourceOnClipEnd(label)));
            }
        }

        private AudioSource PickSource(object label)
        {
            if (label == null)
                return _source;

            if (_labeledSources.ContainsKey(label))
            {
                Debug.LogError($"[HeroSoundPlayer] source with label '{label}' is already registered");
                return null;
            }

            _labeledSources[label] = _source.gameObject.AddComponent<AudioSource>();
            return _labeledSources[label];
        }

        private IEnumerator DestroySourceOnClipEnd(object sourceLabel)
        {
            if (sourceLabel == null)
                yield break;

            AudioSource source = _labeledSources[sourceLabel];
            yield return new WaitForSeconds(source.clip.length);

            RemoveLabeledSource(sourceLabel);
        }

        public void StopSound(object label)
        {
            RemoveLabeledSource(label);
        }

        private void RemoveLabeledSource(object label)
        {
            if (_labeledSources.ContainsKey(label))
            {
                _labeledSources[label].Stop();
                GameObject.Destroy(_labeledSources[label]);

                _labeledSources.Remove(label);
            }
        }

        public void Dispose()
        {
            _destroySourceTasks.ForEach(t => t?.Stop());
            _destroySourceTasks.Clear();
        }
    }
}
