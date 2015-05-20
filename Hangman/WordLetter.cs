
namespace Hangman
{
    public class WordLetter : NotifyPropertyChanged
    {
        private char displayValue;

        public char Value { get; private set; }

        public char DisplayValue
        {
            get { return displayValue; }
            set
            {
                displayValue = value;
                OnPropertyChanged("DisplayValue");
            }
        }

        public WordLetter(char value)
        {
            Value = value;
            displayValue = '_';
        }
    }
}
