
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    public class UnrevealedWord
    {
        public readonly List<WordLetter> Letters;

        public UnrevealedWord(string word)
        {
            Letters = new List<WordLetter>();
            foreach (var letter in word)
            {
                Letters.Add(new WordLetter(letter.ToString()));
            }

            SetHints();
        }

        public void RevealLetter(string letter)
        {
            foreach (var wordLetter in Letters)
            {
                if (wordLetter.Value == letter)
                {
                    wordLetter.DisplayValue = wordLetter.Value;
                }
            }
        }

        public bool IsRevealed()
        {
            return Letters.All(letter => letter.Value == letter.DisplayValue);
        }

        public bool IsValidLetter(string letter)
        {
            return Letters.Any(wordLetter => wordLetter.Value == letter);
        }

        private void SetHints()
        {
            RevealLetter(Letters[0].Value);
            RevealLetter(Letters[Letters.Count - 1].Value);
        }
    }
}
