using NoteBook.ViewModels;
using System;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NoteBook.Commands
{
    public class CreateC : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private NoteFileViewModel noteFileViewModel;
        private TextBox textBox;

        /// <summary>
        /// Create Constructor
        /// </summary>
        /// <param name="pNoteFileViewModel"></param>
        /// <param name="pTextBox"></param>
        public CreateC(NoteFileViewModel pNoteFileViewModel, TextBox pTextBox)
        {
            noteFileViewModel = pNoteFileViewModel;
            textBox = pTextBox;
        }

        //Check if command can Execute
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Let user Edite/type in TextBox to create a new TextFile | Clears TextBox if Clicked again
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            noteFileViewModel.SelectedFile = new Models.NoteFile("", "");
            textBox.Focus(FocusState.Programmatic);

            //Make clickable/unclickable of command Buttons
            noteFileViewModel.canSave = true;
            noteFileViewModel.isNew = true;

            textBox.IsReadOnly = false;
            noteFileViewModel.canDelete = false;
            noteFileViewModel.canEdit = false;

            noteFileViewModel.ChangesMade();
            noteFileViewModel.StartFiltering();
            noteFileViewModel.CreateFileList();

        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}