
namespace Hangman
{
    public class Life : NotifyPropertyChanged
    {
        private int current;

        public int Maximum { get; set; }

        public int Current
        {
            get { return current; }
            set
            {
                current = value;
                OnPropertyChanged("Current");
            }
        }

        public Life(int maximum)
        {
            Maximum = maximum;
            current = maximum;
        }
    }
}
