using NoteBook.Models;
using NoteBook.Repositories;
using NoteBook.ViewModels;
using System;
using System.Windows.Input;

namespace NoteBook.Commands
{
    public class DeleteC : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private NoteFileViewModel nFileViewModel;

        NoteBookRepo noteBookRepo = new NoteBookRepo();

        /// <summary>
        /// Delete Constructor
        /// </summary>
        /// <param name="pNoteFileViewModel"></param>
        public DeleteC(NoteFileViewModel pNoteFileViewModel)
        {
            nFileViewModel = pNoteFileViewModel;
        }

        //Check if command can Execute
        public bool CanExecute(object parameter)
        {
            return nFileViewModel.canDelete;
        }

        /// <summary>
        /// Deletes the Selected File
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            //Delete the selected file from the windows storage
            noteBookRepo.DeleteFile(nFileViewModel.fileName);

            //Set the selected file empty and make the Edit and Save button unclickable
            nFileViewModel.SelectedFile = new NoteFile("", "");
            nFileViewModel.canEdit = false;
            nFileViewModel.canSave = false;

            nFileViewModel.ChangeButtonState();
            nFileViewModel.StartFiltering();
            nFileViewModel.CreateOrDisplayFileList();
        }

        public void FireCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}