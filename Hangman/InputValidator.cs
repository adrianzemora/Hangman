using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class InputValidator
    {
        public bool IsLetterValid(IEnumerable<WordLetter> wordLetters, string letter)
        {
            return wordLetters.Any(wordLetter => wordLetter.Value == letter);
        }
    }
}
