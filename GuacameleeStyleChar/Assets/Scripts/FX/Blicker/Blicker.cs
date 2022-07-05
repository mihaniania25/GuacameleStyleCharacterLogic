using System.Collections;
using UnityEngine;
using GuacameleeStyleChar.Utility;

namespace GuacameleeStyleChar.Fx
{
    public class Blicker
    {
        private const string BLICK_SPEED_PROPERTY = "BlickSpeed";
        private const string BLICK_ENABLED_PROPERTY = "BlickEnabled";

        private Material _material;
        private BlickerData _data;

        private Task _blickTask;

        public Blicker(Material material, BlickerData data)
        {
            _material = material;
            _data = data;
        }

        public void DoBlicking()
        {
            _blickTask?.Stop();
            _blickTask = new Task(BlickingCoro());
        }

        private IEnumerator BlickingCoro()
        {
            _material.SetInteger(BLICK_ENABLED_PROPERTY, 1);
            _material.SetFloat(BLICK_SPEED_PROPERTY, _data.Speed);

            yield return new WaitForSeconds(_data.DurationSec);

            _material.SetInteger(BLICK_ENABLED_PROPERTY, 0);
        }
    }
}
