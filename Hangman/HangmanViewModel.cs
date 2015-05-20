using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace Hangman
{
    public class HangmanViewModel
    {
        private readonly UnrevealedWord unrevealedWord;

        public ObservableCollection<string> AllLetters { get; private set; }
        public ObservableCollection<string> TriedLetters { get; private set; }
        public ObservableCollection<WordLetter> WordLetters { get; private set; }
        public Life Life { get; private set; }
        public ICommand TryLetterCommand { get; private set; }
        public string SelectedLetter { get; set; }

        public HangmanViewModel()
        {
            unrevealedWord = new UnrevealedWord(Word.GetRandom());
            AllLetters = new ObservableCollection<string>(GetAllLetters());
            WordLetters = new ObservableCollection<WordLetter>(unrevealedWord.Letters);
            TryLetterCommand = new Command(TryLetter);
            Life = new Life(6);

            TriedLetters = new ObservableCollection<string>(GetTriedLetters());
            SelectedLetter = TriedLetters[1];
        }

        private void TryLetter()
        {
            if (LetterAlreadyTried())
            {
                return;
            }

            TriedLetters.Add(SelectedLetter);

            if (!unrevealedWord.IsValidLetter(SelectedLetter))
            {
                ProcessInvalidLetter();
                return;
            }

            ProcessValidLetter();
        }

        private void ProcessInvalidLetter()
        {
            Life.Current--;

            if (LivesLeft())
            {
                return;
            }

            unrevealedWord.RevealAllLetters();

            if (RestartGame())
            {
                Process.Start(Application.ResourceAssembly.Location);
            }

            Application.Current.Shutdown();
        }

        private void ProcessValidLetter()
        {
            unrevealedWord.RevealLetter(SelectedLetter);

            if (!unrevealedWord.IsRevealed())
            {
                return;
            }

            if (RestartGame())
            {
                Process.Start(Application.ResourceAssembly.Location);
            }

            Application.Current.Shutdown();
        }

        private bool LetterAlreadyTried()
        {
            return TriedLetters.Contains(SelectedLetter);
        }

        private bool LivesLeft()
        {
            return Life.Current > 0;
        }

        private static bool RestartGame()
        {
            return MessageBox.Show(string.Format("Try Again?"), "Game Over", MessageBoxButton.YesNo,
                MessageBoxImage.Asterisk) == MessageBoxResult.Yes;
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

        private IEnumerable<string> GetTriedLetters()
        {
            List<string> triedLetters = new List<string>();
            string firstLetter = unrevealedWord.Letters[0].Value;
            triedLetters.Add(firstLetter);

            string lastLetter = unrevealedWord.Letters[unrevealedWord.Letters.Count - 1].Value;
            if (!triedLetters.Contains(lastLetter))
            {
                triedLetters.Add(lastLetter);
            }

            return triedLetters;
        }
    }
}
