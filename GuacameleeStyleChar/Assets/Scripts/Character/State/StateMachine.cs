using UnityEngine;

namespace GuacameleeStyleChar.Character
{
    public class StateMachine : MonoBehaviour
    {
        protected State _state;

        public void SetState(State state)
        {
            _state?.Dispose();

            _state = state;
            _state.Start();
            _state.Update();
        }

        private void Update()
        {
            _state?.Update();
        }
    }
}