using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Media_Player
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TagLib.File currentFile;
        private bool mediaPlayerPlaying;
        private bool tagEditorOpen;
        private bool userIsDraggingSlider;

        public MainWindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }


        private void timer_Tick(object sender, EventArgs e)
        {
            if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                MediaSlider.Minimum = 0;
                MediaSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                MediaSlider.Value = mediaPlayer.Position.TotalSeconds;
            }
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

            if ((mediaPlayerPlaying == false) && (mediaPlayer.Source != null)){
                TagEditBtn.IsEnabled = true;
                TagEditorMenu.IsEnabled = true;
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

            TagEditBtn.IsEnabled = true;
            TagEditorMenu.IsEnabled = true;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(MediaSlider.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(MediaSlider.Value).ToString(@"hh\:mm\:ss");
        }

        private void TagEdit_Click(object sender, RoutedEventArgs e)
        {
            // Stop Media Player To Edit Tags
            
            if (TagEditor.Visibility == Visibility.Visible){
                TagEditor.Visibility = Visibility.Hidden;
                tagEditorOpen = false;
            }
            else
            {
                if (mediaPlayerPlaying)
                {
                    mediaPlayer.Stop();
                }
                TagEditor.Visibility = Visibility.Visible;
                tagEditorOpen = true;
            }
        }
    }
}
