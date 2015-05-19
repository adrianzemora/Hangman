using System;
using System.Collections.Generic;
using System.Linq;
using Hangman.Properties;

namespace Hangman.UI
{
    internal static class Word
    {
        private static List<string> words;

        static Word()
        {
            LoadWordsList();
        }

        public static string GetRandom()
        {
            int index = new Random().Next(words.Count);
            return words[index].ToUpperInvariant();
        }

        private static void LoadWordsList()
        {
            words = new List<string>();
            foreach (var word in Resources.WordList.Split('\n').ToList())
            {
                words.Add(word);
            }
        }
    }
}
