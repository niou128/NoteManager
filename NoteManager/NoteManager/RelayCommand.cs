using System;
using System.Windows.Input;

namespace NoteManager
{
    public class RelayCommand : ICommand
    {
        private readonly Action actionToExecute;

        public RelayCommand(Action action)
        {
            actionToExecute = action;
            Console.WriteLine("action = " + actionToExecute.Target.GetType().ToString());
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            actionToExecute();
        }
    }
}
