using System;
using System.Collections.Generic;

namespace KeyHandler
{
    public static class SimpleTypeExtensions
    {
        private static Dictionary<char, Key> SpecialCharacters = BuildSpecialCharacters();
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

        private static Dictionary<char, Key> BuildSpecialCharacters()
        {
            var dictionary = new Dictionary<char, Key>();
            dictionary.Add('/', Key.Slash);
            dictionary.Add('\\', Key.BackSlash);
            dictionary.Add('.', Key.Period);
            dictionary.Add('\t', Key.Tab);
            dictionary.Add(',', Key.Comma);
            dictionary.Add('1', Key.One);
            dictionary.Add('2', Key.Two);
            dictionary.Add('3', Key.Three);
            dictionary.Add('4', Key.Four);
            dictionary.Add('5', Key.Five);
            dictionary.Add('6', Key.Six);
            dictionary.Add('7', Key.Seven);
            dictionary.Add('8', Key.Eight);
            dictionary.Add('9', Key.Nine);
            dictionary.Add('0', Key.Zero);
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
            if (SpecialCharacters.ContainsKey(character))
            {
                return SpecialCharacters[character];
            }

            var charString = character.ToString().ToUpper();
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

            var trimmed = str.Trim();
            return ToKey(trimmed[0]);
        }
    }
}