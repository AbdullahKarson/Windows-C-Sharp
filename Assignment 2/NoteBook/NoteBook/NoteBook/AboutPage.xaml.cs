using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NoteBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AboutPage : Page
    {
        

        public AboutPage()
        {
            this.InitializeComponent();

            //Retrieve Project Information
            Package package = Package.Current;
            PackageId id = package.Id;
            String appName = package.DisplayName;
            String publisher = package.PublisherDisplayName;

            Info.Text = "UWP Application"
                + "\nName: " + appName
                + "\nPublisher: " + publisher
                + "\nVersion: " + id.Version.Major + "." + id.Version.Minor 
                + "." + id.Version.Build + "." + id.Version.Revision;        
        }

        /// <summary>
        /// Return to last Frame
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Visible;

            SystemNavigationManager.GetForCurrentView().BackRequested += About_BackRequested;
        }

        /// <summary>
        /// Check if it can go back a Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void About_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
            e.Handled = true;
        }
    }
}
