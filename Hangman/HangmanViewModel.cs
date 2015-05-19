using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace Hangman
{
    public class HangmanViewModel
    {
        private readonly InputValidator inputValidator;
        public ObservableCollection<string> UntriedLetters { get; private set; }
        public ObservableCollection<WordLetter> WordLetters { get; private set; }
        public Life Life { get; set; }
        public string SelectedLetter { get; set; }
        public ICommand TryLetterCommand { get; private set; }

        public HangmanViewModel()
        {
            inputValidator = new InputValidator();
            string word = Word.GetRandom();

            UntriedLetters = new ObservableCollection<string>(GetAllLetters());
            WordLetters = new ObservableCollection<WordLetter>(GetWordLetters(word));
            TryLetterCommand = new Command(TryLetter);
            Life = new Life(6);
            SetHint();
        }

        private static List<WordLetter> GetWordLetters(string word)
        {
            var letters = new List<WordLetter>();
            foreach (var letter in word)
            {
                letters.Add(new WordLetter(letter.ToString()));
            }
            return letters;
        }

        private void SetHint()
        {
            SelectedLetter = WordLetters[0].Value;
            RevealLetter();

            UntriedLetters.Remove(SelectedLetter);

            SelectedLetter = WordLetters[WordLetters.Count - 1].Value;
            RevealLetter();

            UntriedLetters.Remove(SelectedLetter);
        }


        private void TryLetter()
        {
            if (!inputValidator.IsLetterValid(WordLetters, SelectedLetter))
            {
                Life.Current--;
                if (!LivesLeft())
                {
                    RevealAll();
                    MessageBoxResult choice = MessageBox.Show(string.Format("Try Again?"),
                        "Game Over", MessageBoxButton.YesNo, MessageBoxImage.Error);

                    if (choice == MessageBoxResult.Yes)
                    {
                        Process.Start(Application.ResourceAssembly.Location);
                    }
                    Application.Current.Shutdown();

                }
                UntriedLetters.Remove(SelectedLetter);
                return;
            }

            RevealLetter();

            if (!UnrevealedExist())
            {
                MessageBoxResult choice = MessageBox.Show("Try Again?", "Winner", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                if (choice == MessageBoxResult.Yes)
                {
                    Process.Start(Application.ResourceAssembly.Location);
                }

                Application.Current.Shutdown();
            }

            UntriedLetters.Remove(SelectedLetter);
        }

        private void RevealAll()
        {
            foreach (var wordLetter in WordLetters)
            {
                wordLetter.DisplayValue = wordLetter.Value;
            }
        }

        private bool UnrevealedExist()
        {
            return WordLetters.Any(letter => letter.DisplayValue != letter.Value);
        }

        private void RevealLetter()
        {
            foreach (var wordLetter in WordLetters)
            {
                if (wordLetter.Value == SelectedLetter)
                {
                    wordLetter.DisplayValue = SelectedLetter;
                }
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

        private bool LivesLeft()
        {
            return Life.Current > 0;
        }
    }
}
