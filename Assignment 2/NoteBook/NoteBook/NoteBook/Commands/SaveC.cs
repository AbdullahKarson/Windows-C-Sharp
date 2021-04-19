using NoteBook.Repo;
using NoteBook.Repositories;
using NoteBook.ViewModels;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace NoteBook.Commands
{
    public class SaveC : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private NoteFileViewModel nFileViewModel;
        private TextBox textBox;
        NoteBookRepo noteBookRepo = new NoteBookRepo();

        /// <summary>
        /// Save Constructor
        /// </summary>
        /// <param name="pNoteFileViewModel"></param>
        /// <param name="pTextBox"></param>
        public SaveC(NoteFileViewModel pNoteFileViewModel, TextBox pTextBox)
        {
            nFileViewModel = pNoteFileViewModel;
            textBox = pTextBox;
        }

        //Check if command can Execute
        public bool CanExecute(object parameter)
        {
            return nFileViewModel.canSave;
        }

        /// <summary>
        /// Save TextName and its Content to a file
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        {

            //Check if name already exists
            if (nFileViewModel.isNew)
            {
                SaveDialog saveDialog = new SaveDialog(nFileViewModel);
                await saveDialog.ShowAsync();
                //Create a new file
                if (!saveDialog.IsExecuted)
                {
                    //noteBookRepo.CreateNewFile(saveDialog.fName, textBox.Text);
                    DBNoteBook.InsertNote(saveDialog.fName,textBox.Text);
                }
            }
            else
            {
                //Write to an existing file
                //noteBookRepo.WriteToFile(textBox.Text, nFileViewModel.fileName);
                DBNoteBook.UpdateNote(nFileViewModel.fileName, textBox.Text);
            }


            //Update the files collection and allow file searching
            nFileViewModel.CreateOrDisplayFileList();
            nFileViewModel.StartFiltering();

            //Make clickable/unclickable of command Buttons
            textBox.IsReadOnly = true;
            nFileViewModel.canEdit = false;
            nFileViewModel.canDelete = false;
            nFileViewModel.canSave = false;

            nFileViewModel.ChangeButtonState();

            //Set Text box to blank
            textBox.Text = "";
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}