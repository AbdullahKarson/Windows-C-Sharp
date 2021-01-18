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
            //Grid mainGrid = this.mainGrid;

            //Button newHiddenButton = new Button
            //{
            //    Content = "I'm New",
            //    Width = 120,
            //    Height = 60
            //};

            //mainGrid.Children.Add(newHiddenButton);
            //Grid.SetColumn(newHiddenButton, 0);
            //Grid.SetRow(newHiddenButton, 2);

            //Get num of columns in the Grid
            int numCols = this.mainGrid.ColumnDefinitions.Count;

            //Which col is the button currentl in?
            int currColIndex = Grid.GetColumn(ClickMeButton);

            //Move to the right, unless already in last column. If so move to first cloumn in next row
            if (currColIndex != numCols - 1)
            {
                Grid.SetColumn(ClickMeButton, currColIndex + 1);
            }
            else
            {
                Grid.SetColumn(ClickMeButton, 0);
            }
        }
    }
}
