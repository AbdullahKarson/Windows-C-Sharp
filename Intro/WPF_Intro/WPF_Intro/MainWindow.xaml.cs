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

namespace WPF_Intro
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ClickMeButton_Click(object sender, RoutedEventArgs e)
        {
            Button newHiddenButton = new Button
            {
                Content = "I'm New",
                Width = 120,
                Height = 60
            };
            Grid mainGrid = this.mainGrid;
            mainGrid.Children.Add(newHiddenButton);
            Grid.SetColumn(newHiddenButton, 0);
            Grid.SetRow(newHiddenButton, 2);
        }
    }
}
