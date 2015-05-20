
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Hangman
{
    class HangmanGame
    {
        private readonly UnrevealedWord unrevealedWord;

        public Life Life { get; private set; }
        public IList<string> InvalidLetters { get; private set; }

        public HangmanGame(UnrevealedWord unrevealedWord)
        {
            this.unrevealedWord = unrevealedWord;
            Life = new Life(6);
            InvalidLetters = new List<string>();
        }

        public void TryLetter(string letter)
        {
            if (InvalidLetters.Contains(letter))
            {
                return;
            }

            if (!unrevealedWord.IsValidLetter(letter))
            {
                ProcessInvalidLetter(letter);
                return;
            }

            ProcessValidLetter(letter);
        }

        private void ProcessInvalidLetter(string letter)
        {
            InvalidLetters.Add(letter);
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

        private void ProcessValidLetter(string letter)
        {
            unrevealedWord.RevealLetter(letter);

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

        private bool LivesLeft()
        {
            return Life.Current > 0;
        }

        private static bool RestartGame()
        {
            return MessageBox.Show(string.Format("Try Again?"), "Game Over", MessageBoxButton.YesNo,
                MessageBoxImage.Asterisk) == MessageBoxResult.Yes;
        }
    }
}
