using System;
using System.Collections.Generic;
using System.Diagnostics;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TC2_RegistrationWizard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Page3 : Page
    {
        User user = (User)Application.Current.Resources["user"];

        public Page3()
        {
            this.InitializeComponent();
            tbEmail.Text = user.Email ?? "";
            tbHomePage.Text = user.HomePage ?? "";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            user.Email = tbEmail.Text ?? "";
            user.HomePage = tbHomePage.Text ?? "";
            Frame.Navigate(typeof(Page2));
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            user.Email = tbEmail.Text ?? "";
            user.HomePage = tbHomePage.Text ?? "";

            Debug.WriteLine("First Name: " + user.FirstName);
            Debug.WriteLine("Last Name: " + user.LastName);
            Debug.WriteLine("Password: " + user.Password);
            Debug.WriteLine("Address: " + user.Address);
            Debug.WriteLine("City: " + user.City);
            Debug.WriteLine("Postal Code: " + user.Postal);
            Debug.WriteLine("Email: " + user.Email.ToString());
            Debug.WriteLine("Homepage: " + user.HomePage.ToString());
        }
    }
}
