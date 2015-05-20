using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hangman
{
    public class HangmanViewModel
    {
        private readonly HangmanGame hangmanGame;

        public ObservableCollection<string> AllLetters { get; private set; }
        public ObservableCollection<string> InvalidLetters { get; private set; }
        public ObservableCollection<WordLetter> WordLetters { get; private set; }
        public Life Life { get; private set; }
        public ICommand TryLetterCommand { get; private set; }
        public string SelectedLetter { get; set; }

        public HangmanViewModel()
        {
            var unrevealedWord = new UnrevealedWord(Word.GetRandom());
            AllLetters = new ObservableCollection<string>(GetAllLetters());
            WordLetters = new ObservableCollection<WordLetter>(unrevealedWord.Letters);
            TryLetterCommand = new Command(TryLetter);

            ivate set = new ObservableCollection<string>();
            SelectedLetter = AllLetters[0];

            hangmanGame = new HangmanGame(unrevealedWord);
            Life = hangmanGame.Life;
        }

        private void TryLetter()
        {
            hangmanGame.TryLetter(SelectedLetter);
            RefreshInvalidLetters(hangmanGame.InvalidLetters);
            Life = hangmanGame.Life;
        }

        private void RefreshInvalidLetters(IEnumerable<string> invalidLetters)
        {
            InvalidLetters.Clear();
            foreach (var invalidLetter in invalidLetters)
            {
                InvalidLetters.Add(invalidLetter);
            }
        }

        private static IEnumerable<string> GetAllLetters()
        {
            var unselectedLetters = new List<string>();
            for (char i = 'A'; i <= 'Z'; i++)
            {
                unselectedLetters.Add(i.ToString());
            }

            return unselectedLetters;
        }
    }
}
