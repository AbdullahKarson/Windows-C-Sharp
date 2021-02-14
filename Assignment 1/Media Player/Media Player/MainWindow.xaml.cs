﻿using Microsoft.Win32;
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
        private bool userIsDraggingSlider;

        public MainWindow()
        {
            InitializeComponent();
            TagEditBtn.OpenTagger += new EventHandler(OpenTagWindow);
            TagEditorMenu.OpenTagger += OpenTagWindow;
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

                //set Tag Info on WPF
                Title.Text = currentFile.Tag.Title;
                Artist.Text = currentFile.Tag.FirstAlbumArtist;
                Album.Text = currentFile.Tag.Album;
            }

            if ((mediaPlayerPlaying == false) && (mediaPlayer.Source != null)){
                TagEditorMenu.IsEnabled = true;
                TagEditBtn.IsEnabled = true;
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

            //set Tag Edit Buttons to Enabled
            TagEditBtn.IsEnabled = true;
            TagEditorMenu.IsEnabled = true;
        }

        //user started dragging slider
        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        //user finished gragging slider and song position changes to new slider position time
        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(MediaSlider.Value);
        }

        //timer gets new value each second
        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(MediaSlider.Value).ToString(@"hh\:mm\:ss");
        }

        //open Tagging window
        private void OpenTagWindow(object sender, EventArgs e)
        {
            if (TagEditor.Visibility == Visibility.Visible)
            {
                TagEditor.Visibility = Visibility.Hidden;
            }
            else
            {
                if (mediaPlayerPlaying)
                {
                    mediaPlayer.Stop();
                }

                TitleEditor.Text = Title.Text;
                ArtistEditor.Text = Artist.Text;
                AlbumEditor.Text = Album.Text;

                TagEditor.Visibility = Visibility.Visible;
            }
        }

        private void SubmitTag_Click(object sender, RoutedEventArgs e)
        {
            currentFile.Tag.Title = TitleEditor.Text;
            currentFile.Tag.AlbumArtists = null;
            currentFile.Tag.AlbumArtists = new[] { ArtistEditor.Text};
            currentFile.Tag.Album = null;
            currentFile.Tag.Album = AlbumEditor.Text;

            currentFile.Save();

            if (TagEditor.Visibility == Visibility.Visible)
            {
                TagEditor.Visibility = Visibility.Hidden;

                //set Tag Info on WPF
                Title.Text = currentFile.Tag.Title;
                Artist.Text = currentFile.Tag.FirstAlbumArtist;
                Album.Text = currentFile.Tag.Album;
            }
        }
    }
}
