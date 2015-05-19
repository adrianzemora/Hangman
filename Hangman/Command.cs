using System;
using System.Windows.Input;

namespace Hangman
{
    public class Command : ICommand
    {
        private readonly Action action;

        public event EventHandler CanExecuteChanged = delegate { };

        public Command(Action action)
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