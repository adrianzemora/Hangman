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
        public ObservableCollection<string> UntriedLetters { get; private set; }
        public ObservableCollection<WordLetter> WordLetters { get; private set; }
        public Life Life { get; set; }
        public string SelectedLetter { get; set; }
        public ICommand TryLetterCommand { get; private set; }

        public HangmanViewModel()
        {
            string word = Word.GetRandom();
            unrevealedWord = new UnrevealedWord(word);

            UntriedLetters = new ObservableCollection<string>(GetAllLetters());
            WordLetters = new ObservableCollection<WordLetter>(unrevealedWord.Letters);
            TryLetterCommand = new Command(TryLetter);
            Life = new Life(6);
        }


        private void TryLetter()
        {
            if (!unrevealedWord.IsValidLetter(SelectedLetter))
            {
                DecreaseLife();

                if (LivesLeft())
                {
                    return;
                }

                unrevealedWord.Reveal();
                if (RestartGame())
                {
                    Process.Start(Application.ResourceAssembly.Location);
                }

                Application.Current.Shutdown();
            }
            else
            {

                unrevealedWord.RevealLetter(SelectedLetter);

                if (unrevealedWord.IsRevealed())
                {
                    if (RestartGame())
                    {
                        Process.Start(Application.ResourceAssembly.Location);
                    }

                    Application.Current.Shutdown();
                }
            }

        }

        private void DecreaseLife()
        {
            Life.Current--;
        }

        private bool RestartGame()
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

        private bool LivesLeft()
        {
            return Life.Current > 0;
        }

    }
}
