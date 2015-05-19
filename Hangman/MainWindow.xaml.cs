using System.Collections.Generic;
using System.Windows;

namespace Hangman.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly List<char> selectedChars = new List<char>();
        private readonly string targetWord;
        private readonly List<char> targetChars;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new HangmanViewModel();



            //targetWord = Word.GetRandom();
            //targetChars = GetUniqueWordChars();
            //DisplayWord();
            //DisplayUntriedLetters();
        }

        //private List<char> GetUniqueWordChars()
        //{
        //    List<char> charList = new List<char>();
        //    foreach (char character in targetWord)
        //    {
        //        if (charList.Contains(character))
        //        {
        //            continue;
        //        }

        //        charList.Add(character);
        //    }

        //    return charList;
        //}

        //private void DisplayUntriedLetters()
        //{
        //    PnlCharacters.Children.Clear();

        //    for (char i = 'A'; i <= 'Z'; i++)
        //    {
        //        if (selectedChars.Contains(i))
        //        {
        //            continue;
        //        }

        //        Button button = new Button { Content = i, Width = 48, Height = 25 };
        //        button.Click += ButtonClick;
        //        PnlCharacters.Children.Add(button);
        //    }
        //}

        //private void ButtonClick(object sender, RoutedEventArgs e)
        //{
        //    var button = (Button)sender;
        //    char selected = button.Content.ToString()[0];
        //    selectedChars.Add(selected);

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

        //private void DisplayWord()
        //{
        //    PnlWord.Children.Clear();
        //    Brush backgroundColor = Brushes.White;
        //    if (PrgLivesLeft.Value <= 0)
        //    {
        //        backgroundColor = targetChars.Count == 0 ? Brushes.GreenYellow : Brushes.Salmon;
        //    }

        //    foreach (char character in targetWord)
        //    {
        //        var textBox = new TextBox
        //        {
        //            Background = backgroundColor,
        //            BorderThickness = new Thickness(2),
        //            VerticalContentAlignment = VerticalAlignment.Bottom,
        //            IsReadOnly = true,
        //            FontSize = 15,
        //            Text = string.Format("{0} ", targetChars.Contains(character) ? "_" : character.ToString())
        //        };

        //        PnlWord.Children.Add(textBox);
        //    }
        //}
    }
}
