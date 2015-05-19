
namespace Hangman
{
    public class WordLetter
    {
        public string Value { get; set; }
        public string DisplayValue { get; set; }

        public WordLetter(string value)
        {
            Value = value;
            DisplayValue = "_";
        }
    }
}
