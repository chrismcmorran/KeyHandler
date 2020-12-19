using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KeyHandler
{
    /// <summary>
    /// These are the keys defined by the KeyHandler.
    /// </summary>
    public enum Key
    {
        A = 0x41,
        B = 0x42,
        C = 0x43,
        D = 0x44,
        E = 0x45,
        F = 0x46,
        G = 0x47,
        H = 0x48,
        I = 0x49,
        J = 0x4A,
        K = 0x4B,
        L = 0x4C,
        M = 0x4D,
        N = 0x4E,
        O = 0x4F,
        P = 0x50,
        Q = 0x51,
        R = 0x52,
        S = 0x53,
        T = 0x54,
        U = 0x55,
        V = 0x56,
        W = 0x57,
        X = 0x58,
        Y = 0x59,
        Z = 0x5A,
        LeftShift = 0xA0,
        RightShift = 0xA1,
        LeftControl = 0xA2,
        RightControl = 0xA3,
        Up = 0x26,
        Down = 0x28,
        Left = 0x25,
        Right = 0x27,
        Alt = 0x12,
        Tab = 0x09,
        Windows = 0x5B,
        Slash = 0xBF,
        Period = 0xBE,
        Comma = 0xBC,
        BackSlash = 0xDC,
        BackSpace = 0x08,
        One = 0x31,
        Two = 0x32,
        Three = 0x33,
        Four = 0x34,
        Five = 0x35,
        Six = 0x36,
        Seven = 0x37,
        Eight = 0x38,
        Nine = 0x39,
        Zero = 0x30
    }
    
    /// <summary>
    /// The key handler class.
    /// </summary>
    public static class KeyHandler
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(System.Int32 vKey);

        private static bool VKeyIsPressed(System.Int32 vKey)
        {
            return GetAsyncKeyState(vKey & 0x8000) != 0;
        }

        /// <summary>
        /// Determines if the provided key is currently pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>True if pressed.</returns>
        public static bool IsPressed(Key key)
        {
            return VKeyIsPressed((System.Int32) key);
        }

        /// <summary>
        /// Gets all of the Keys which are currently pressed.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Key> GetPressedKeys()
        {
            var pressedKeys = new List<Key>();
            foreach (var key in (Key[]) Enum.GetValues(typeof(Key)))
            {
                if (IsPressed(key))
                {
                    pressedKeys.Add(key);
                }
            }

            return pressedKeys;
        }
    }
}