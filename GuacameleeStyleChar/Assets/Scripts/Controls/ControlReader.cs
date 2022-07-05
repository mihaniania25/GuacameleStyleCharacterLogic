using UnityEngine;

namespace GuacameleeStyleChar.Control
{
    public static class ControlReader
    {
        public static bool MoveRight => Input.GetKey(KeyCode.D);
        public static bool MoveLeft => Input.GetKey(KeyCode.A);
        public static bool Jump => Input.GetKeyDown(KeyCode.Space);
        public static bool JumpHold => Input.GetKey(KeyCode.Space);
    }
}