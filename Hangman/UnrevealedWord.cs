
using System.Collections.Generic;

namespace Hangman
{
    internal class UnrevealedWord
    {
        private List<WordLetter> wordLetters = new List<WordLetter>();

        public UnrevealedWord(string word)
        {
            foreach (var letter in word)
            {
                wordLetters.Add(new WordLetter(letter.ToString()));
            }
        }

        public void RevealLetter(string letter)
        {
            foreach (var wordLetter in wordLetters)
            {
                if (wordLetter.Value == letter)
                {
                    wordLetter.DisplayValue = wordLetter.Value;
                }
            }
        }
    }
}
