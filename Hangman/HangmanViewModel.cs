using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hangman
{
    public class HangmanViewModel
    {
        public ObservableCollection<string> UntriedLetters { get; private set; }
        public ObservableCollection<WordLetter> WordLetters { get; private set; }
        public string SelectedLetter { get; set; }
        public ICommand TryLetterCommand { get; private set; }

        public HangmanViewModel()
        {
            UntriedLetters = new ObservableCollection<string>(GetAllLetters());
            TryLetterCommand = new TryLetterCommand(TryLetter);
            WordLetters = new ObservableCollection<WordLetter>(GetWordLetters(Word.GetRandom()));
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

        private void TryLetter()
        {
            //    if (targetChars.Contains(selected))
            //    {
            //        targetChars.Remove(selected);
            //    }
            //    else
            //    {
            //        double livesLeft = PrgLivesLeft.Value - 1;
            //        LblLivesLeft.Content = livesLeft;
            //        PrgLivesLeft.Value = livesLeft;
            //    }

            //    DisplayWord();

            //    if (targetChars.Count != 0)
            //    {
            //        DisplayUntriedLetters();
            //    }
            //    else
            //    {
            //        MessageBoxResult choice = MessageBox.Show("Congruatulations! Try Again?", "Winner", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
            //        if (choice == MessageBoxResult.Yes)
            //        {
            //            Process.Start(Application.ResourceAssembly.Location);
            //        }

            //        Application.Current.Shutdown();
            //    }

            //    if (PrgLivesLeft.Value <= 0)
            //    {
            //        MessageBoxResult choice = MessageBox.Show(string.Format("The expected word was: {0}. Try Again?", targetWord),
            //            "Game Over", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);

            //        if (choice == MessageBoxResult.Yes)
            //        {
            //            Process.Start(Application.ResourceAssembly.Location);
            //        }
            //        Application.Current.Shutdown();
            //    }
            //}

            UntriedLetters.Remove(SelectedLetter);
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
