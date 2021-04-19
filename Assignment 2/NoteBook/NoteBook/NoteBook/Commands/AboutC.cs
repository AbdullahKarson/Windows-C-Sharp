using System;
using System.Windows.Input;
using Windows.UI.Popups;

namespace NoteBook.Commands
{
    public class AboutC : ICommand
    {
        public event EventHandler CanExecuteChanged;

        //Check if command can Execute
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Display Application Info
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        { 
            //About Message
            string message = "UWP Application\nMade By: Abdullah Karson";
            message = message.ToUpper();

            //Initialize new MessageDialog instance
            MessageDialog messageDialog = new MessageDialog(message, "Note Book");

            //Display the message dialog
            await messageDialog.ShowAsync();
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
