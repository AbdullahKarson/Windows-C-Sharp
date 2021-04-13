using System;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace NoteBook.Commands
{
    public class ExitC : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //Check if command can Execute
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Exit Application
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            Application.Current.Exit();
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
