
namespace Hangman
{
    public class WordLetter : NotifyPropertyChanged
    {
        private string displayValue;

        public string Value { get; private set; }

        public string DisplayValue
        {
            get { return displayValue; }
            set
            {
                displayValue = value;
                OnPropertyChanged("DisplayValue");
            }
        }

        public WordLetter(string value)
        {
            Value = value;
            displayValue = "_";
        }
    }
}
