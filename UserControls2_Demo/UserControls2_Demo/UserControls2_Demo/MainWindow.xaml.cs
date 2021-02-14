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

namespace UserControls2_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IncrUserControl.IncrementMe += new EventHandler(IncrUserControl_Incremented);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Login myLogin = new Login();
            MainGrid.Children.Add(myLogin);

            Grid.SetColumn(myLogin, 0);
            Grid.SetRow(myLogin, 1);
        }

        private void IncrUserControl_Incremented(object sender, EventArgs e)
        {
            int x = int.Parse(DisplayBox.Text);
            DisplayBox.Text = (x + 1).ToString();
        }
    }
}
