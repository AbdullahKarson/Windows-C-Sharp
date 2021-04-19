using NoteBook.Commands;
using NoteBook.Models;
using NoteBook.Repo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace NoteBook.ViewModels
{
    public class NoteFileViewModel : INotifyPropertyChanged
    {
        //Initiate Commands
        public AboutC aboutC { get; }
        public CreateC createC { get; }
        public DeleteC deleteC { get; }
        public EditC editC { get; }
        public ExitC exitC { get; }
        public SaveC saveC { get; }

        //Initiate Textbox
        private TextBox textBox;

        //Initiate PropertyChangedEventHandler
        public event PropertyChangedEventHandler PropertyChanged;

        //Initiate an ObservableCollection
        public ObservableCollection<NoteFile> NoteFiles { get; set; }

        //Initiate a new List on noteFiles in Notebook
        private List<NoteFile> noteFiles = new List<NoteFile>();

        //The Current File
        private NoteFile currentFile;

        //check if File is new bool
        public bool isNew = true;

        //Make Buttons accessible
        public bool canEdit { get; set; } = true;
        public bool canSave { get; set; } = true;
        public bool canDelete { get; set; } = false;


        //public string fileDesc { get; set; }
        public string fileName { get; set; }
        public string fileContent { get; set; }

        private string _filter;

        public NoteFileViewModel() {
            // create an object of NoteFile collection
            NoteFiles = new ObservableCollection<NoteFile>();

            // create a list of files
            CreateOrDisplayFileList();

            //Perform Filtering
            //StartFiltering();
        }

        public NoteFileViewModel(TextBox tBox)
        {
            textBox = tBox;

            // create an object of NoteFile collection
            NoteFiles = new ObservableCollection<NoteFile>();

            // initialize the commands when called
            this.deleteC = new DeleteC(this);
            this.createC = new CreateC(this, tBox);
            this.editC = new EditC(this, tBox);
            this.saveC = new SaveC(this, tBox);
            this.exitC = new ExitC();
            this.aboutC = new AboutC();


            // create a list of files
            CreateOrDisplayFileList();

            //Perform Filtering
            StartFiltering();
        }

        /// <summary>
        /// Retrieve the selected file and change status of Buttons
        /// </summary>
        public NoteFile SelectedFile
        {
            get { return currentFile; }
            set
            {
                currentFile = value;

                if (value != null)
                {
                    fileName = value.fileName;
                    fileContent = value.fileContent;
                    textBox.IsReadOnly = true;
                    canDelete = true;
                    canEdit = true;
                    canSave = false;
                    isNew = false;
                }

                // envoke the event handler with filename and filetext changes
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("fileName"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("fileContent"));

                // update the command event handlers 
                ChangeButtonState();
            }
        }

        /// <summary>
        ///Set the command event handlers
        /// </summary>
        public void ChangeButtonState()
        {
            deleteC.FireCanExecuteChanged();
            createC.FireCanExecuteChanged();
            editC.FireCanExecuteChanged();
            saveC.FireCanExecuteChanged();
            exitC.FireCanExecuteChanged();
            aboutC.FireCanExecuteChanged();

        }

        /// <summary>
        /// Filter the file names
        /// </summary>
        public void StartFiltering()
        {
            NoteFiles.Clear();

            //If filter is null set it to ""
            if (_filter == null)
            {
                _filter = "";
            }

            // filter the value with lower case and trim string
            var lowerCaseFilter = Filter.ToLowerInvariant().Trim();

            //Use LINQ query to get all file names
            var result =
                noteFiles.Where(d => d.fileName.ToLowerInvariant()
                .Contains(lowerCaseFilter))
                .ToList();

            //Get list of values in current filtered list that we want to remove
            //(ie. don't meet new filter criteria)
            var toRemove = NoteFiles.Except(result).ToList();

            //Loop to remove items that fail filter
            foreach (var x in toRemove)
            {
                NoteFiles.Remove(x);
            }

            var resultCount = result.Count;

            // Add back in correct order.
            for (int i = 0; i < resultCount; i++)
            {
                var resultItem = result[i];
                if (i + 1 > NoteFiles.Count || !NoteFiles[i].Equals(resultItem))
                {
                    NoteFiles.Insert(i, resultItem);
                }
            }
        }

        /// <summary>
        /// Returns Filtered Values
        /// </summary>
        public string Filter
        {
            get { return _filter; }
            set
            {
                if (value == _filter) { return; }
                _filter = value;
                StartFiltering();

                // invoke whenever the property is changed
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Filter)));
            }
        }

        /// <summary>
        /// Display the existing file names
        /// </summary>
        public async void CreateOrDisplayFileList()
        {
            noteFiles.Clear();
            NoteFiles.Clear();

            noteFiles = DBNoteBook.RetrieveAllFiles();

            //StorageFolder textFolder = ApplicationData.Current.LocalFolder;

            //IReadOnlyList<StorageFile> storageFiles = await textFolder.GetFilesAsync();

            ////For each file input into all files list
            //foreach (StorageFile file in storageFiles)
            //{
            //    if (file != null)
            //    {
            //        try
            //        {
            //            // display file names from the list
            //            noteFiles.Add(new NoteFile(file.DisplayName, await FileIO.ReadTextAsync(file)));
            //        }
            //        catch (FileNotFoundException ex)
            //        {
            //            Debug.WriteLine("Oh noes! File not found " + ex.Message);
            //        }
            //    }
            //}

            // call the perform filtering
            StartFiltering();
        }

        /// <summary>
        /// Check whether the filename is already exist or not
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool NameExists(string text)
        {
            foreach (NoteFile file in NoteFiles)
            {
                if (text == file.fileName)
                {
                    return true;
                }
            }

            return false;
        }



    }
}