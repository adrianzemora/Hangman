using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace Hangman.UI
{
    public class TryLetterCommand : ICommand
    {
        private readonly Action action;

        public event EventHandler CanExecuteChanged = delegate { };

        public TryLetterCommand(Action action)
        {
            this.action = action;
        }

        public void Execute(object parameter)
        {
            action();
        }

        public bool CanExecute(object parameter)
        {
            Button button = (Button)parameter;

            return true;
        }
    }
}