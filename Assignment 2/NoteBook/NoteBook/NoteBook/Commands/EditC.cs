using NoteBook.ViewModels;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace NoteBook.Commands
{
    public class EditC : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private NoteFileViewModel nFileViewModel;
        private TextBox textBox;

        /// <summary>
        /// Edit Constructor
        /// </summary>
        /// <param name="pNoteFileViewModel"></param>
        /// <param name="pTextBox"></param>
        public EditC(NoteFileViewModel pNoteFileViewModel, TextBox pTextBox)
        {
            nFileViewModel = pNoteFileViewModel;
            textBox = pTextBox;
        }

        //Check if command can Execute
        public bool CanExecute(object parameter)
        {
            return nFileViewModel.canEdit;
        }

        /// <summary>
        /// Let user Edit Selected File
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            //Make clickable/unclickable of command Buttons
            nFileViewModel.canSave = true;
            textBox.IsReadOnly = false;
            nFileViewModel.canEdit = false;
            nFileViewModel.isNew = false;

            nFileViewModel.ChangeButtonState();
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
