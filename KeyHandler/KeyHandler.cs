using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace KeyHandler
{
    /// <summary>
    /// The key handler class.
    /// </summary>
    public static class KeyHandler
    {
        [DllImport("User32.dll")]
        private static extern short GetAsyncKeyState(Int32 vKey);

        private static Key[] Keys = Enum.GetValues(typeof(Key)) as Key[];

        /// <summary>
        /// Determines if the provided key is currently pressed.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>True if pressed.</returns>
        public static bool IsPressed(Key key)
        {
            return GetAsyncKeyState((Int32)key) < 0;
        }

        /// <summary>
        /// Gets all of the Keys which are currently pressed.
        /// </summary>
        /// <returns></returns>
        public static ISet<Key> GetPressedKeys()
        {
            var pressedKeys = new HashSet<Key>();
            foreach (var key in Keys)
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