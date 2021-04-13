using NoteBook.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NoteBook
{
    public sealed partial class SaveDialog : ContentDialog
    {
        NoteFileViewModel nFileViewModel;
        public string fName = "";
        public bool IsExited = false;
        public bool IsValid = false;

        public SaveDialog(NoteFileViewModel pNoteFileViewModel)
        {
            nFileViewModel = pNoteFileViewModel;
            this.InitializeComponent();

        }

        private void ContentDialog_SaveButton(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            if (string.IsNullOrEmpty(fileName.Text))
            {
                args.Cancel = true;
                msgBox.Text = "Please Enter a Name!";

            }
            else if (nFileViewModel.NameExists(fileName.Text))
            {
                args.Cancel = true;
                msgBox.Text = "Name is already taken!";
            }
            else
            {
                IsValid = true;
                args.Cancel = false;
                fName = fileName.Text;
            }
        }

        private void ContentDialog_CancelButton(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            this.fName = "";
            this.IsExited = true;
        }
    }
}
