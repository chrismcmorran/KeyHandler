using System;
using System.Collections.Generic;

namespace KeyHandler
{
    public static class SimpleTypeExtensions
    {
        private static Dictionary<string, Key> SpecialCharacters = BuildSpecialCharacters();
        private static Dictionary<string, Key> KeyValueLookup = BuildLookup();

        private static Dictionary<string, Key> BuildLookup()
        {
            var dictionary = new Dictionary<string, Key>();
            var names = Enum.GetNames(typeof(Key));
            var values = (Key[])Enum.GetValues(typeof(Key));
            for (int i = 0; i < names.Length; i++)
            {
                dictionary.Add(names[i], values[i]);
            }

            return dictionary;
        }

        private static Dictionary<string, Key> BuildSpecialCharacters()
        {
            var dictionary = new Dictionary<string, Key>
            {
                {"/", Key.Slash},
                {"\\", Key.BackSlash},
                {".", Key.Period},
                {"\t", Key.Tab},
                {",", Key.Comma},
                {" ", Key.Space},
                {"1", Key.One},
                {"2", Key.Two},
                {"3", Key.Three},
                {"4", Key.Four},
                {"5", Key.Five},
                {"6", Key.Six},
                {"7", Key.Seven},
                {"8", Key.Eight},
                {"9", Key.Nine},
                {"0", Key.Zero},
                {"UP", Key.Up},
                {"DOWN", Key.Down},
                {"LEFT", Key.Left},
                {"RIGHT", Key.Right}
            };
            return dictionary;
        }

        /// <summary>
        /// Attempts to convert the provided key to a Key enum.
        /// Throws an exception on bad input.
        /// </summary>
        /// <param name="character">The char.</param>
        /// <returns>A key.</returns>
        public static Key ToKey(this char character)
        {
            var charString = character.ToString().ToUpper();
            if (SpecialCharacters.ContainsKey(charString))
            {
                return SpecialCharacters[charString];
            }
            
            if (KeyValueLookup.ContainsKey(charString))
            {
                return KeyValueLookup[charString];
            }

            throw new Exception("Failed to convert to Key");
        }
        
        /// <summary>
        /// Attempts to convert the provided key (string) to a Key enum.
        /// Throws an exception on bad input.
        /// </summary>
        /// <param name="str">The char.</param>
        /// <returns>A key.</returns>
        public static Key ToKey(this string str)
        {
            if (str.Length < 1)
            {
                throw new Exception("Empty string");
            }

            var charString = str.ToUpper().Trim();
            if (SpecialCharacters.ContainsKey(charString))
            {
                return SpecialCharacters[charString];
            }
            
            if (KeyValueLookup.ContainsKey(charString))
            {
                return KeyValueLookup[charString];
            }

            return ToKey(charString[0]);
        }
    }
}