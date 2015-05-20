using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hangman
{
    public class HangmanViewModel
    {
        private readonly HangmanGame hangmanGame;

        public ObservableCollection<char> UserPossibilities { get; private set; }
        public ObservableCollection<char> MisGuessedLetters { get; private set; }
        public ObservableCollection<WordLetter> WordLetters { get; private set; }
        public Life Life { get; private set; }
        public ICommand TryLetterCommand { get; private set; }
        public char UserChoice { get; set; }

        public HangmanViewModel()
        {
            var unrevealedWord = new UnrevealedWord(Word.GetRandom());
            WordLetters = new ObservableCollection<WordLetter>(unrevealedWord.Letters);
            UserPossibilities = new ObservableCollection<char>(GetUserPosibilities());
            TryLetterCommand = new Command(TryLetter);

            MisGuessedLetters = new ObservableCollection<char>();
            UserChoice = UserPossibilities[0];

            hangmanGame = new HangmanGame(unrevealedWord);
            Life = new Life(hangmanGame.MaximumLife);
        }

        private void TryLetter()
        {
            hangmanGame.TryLetter(UserChoice);
            RefreshMisGuessedLetters(hangmanGame.InvalidLetters);
            Life.Current = hangmanGame.CurrentLife;
        }

        private void RefreshMisGuessedLetters(IEnumerable<char> misGuessedLetters)
        {
            MisGuessedLetters.Clear();
            foreach (var letter in misGuessedLetters)
            {
                MisGuessedLetters.Add(letter);
            }
        }

        private static IEnumerable<char> GetUserPosibilities()
        {
            var userPosibilities = new List<char>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                userPosibilities.Add(i);
            }

            return userPosibilities;
        }
    }
}
