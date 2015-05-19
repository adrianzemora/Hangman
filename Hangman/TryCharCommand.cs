using System;
using System.Windows.Input;

namespace Hangman
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
            return true;
        }
    }
}