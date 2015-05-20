
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace Hangman
{
    class HangmanGame
    {
        private readonly UnrevealedWord unrevealedWord;

        public int MaximumLife { get; private set; }
        public int CurrentLife { get; private set; }
        public IList<char> InvalidLetters { get; private set; }

        public HangmanGame(UnrevealedWord unrevealedWord)
        {
            this.unrevealedWord = unrevealedWord;
            InvalidLetters = new List<char>();
            MaximumLife = 6;
            CurrentLife = MaximumLife;
        }

        public void TryLetter(char letter)
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

        private void ProcessInvalidLetter(char letter)
        {
            InvalidLetters.Add(letter);
            CurrentLife--;

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

        private void ProcessValidLetter(char letter)
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
            return CurrentLife > 0;
        }

        private static bool RestartGame()
        {
            return MessageBox.Show(string.Format("Try Again?"), "Game Over", MessageBoxButton.YesNo,
                MessageBoxImage.Asterisk) == MessageBoxResult.Yes;
        }
    }
}
