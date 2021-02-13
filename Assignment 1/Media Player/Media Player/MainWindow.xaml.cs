using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Media_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TagLib.File currentFile;
        private bool mediaPlayerPlaying;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Close_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //open File Dialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //Filter File Dialog for only mp3 files
            openFileDialog.Filter = "Media files (*.mp3)|*.mp3|All files (*.*)|*.*";

            //if mp3 opens:
            if (openFileDialog.ShowDialog() == true)
            {
                //set media player from selected file
                mediaPlayer.Source = new Uri(openFileDialog.FileName);

                //Set the source of the media player element.
                currentFile = TagLib.File.Create(openFileDialog.FileName);
            }
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //only play when mediaplayer has value and source has value
            e.CanExecute = (mediaPlayer != null) && (mediaPlayer.Source != null);
        }
        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //play media source
            mediaPlayer.Play();
            //set bool mediaPlayerPlaying as true
            mediaPlayerPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //pause if mediaPlayerPlaying is true
            e.CanExecute = mediaPlayerPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //pause media player
            mediaPlayer.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            //stop if mediaPlayerPlaying is true
            e.CanExecute = mediaPlayerPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            //stop media player
            mediaPlayer.Stop();
            mediaPlayerPlaying = false;
        }
    }
}
