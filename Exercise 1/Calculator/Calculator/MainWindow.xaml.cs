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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Double firstNum; 
        Double secondNum;

        Boolean AdditionM = false;
        Boolean SubtractionM = false;
        Boolean MultiplicationM = false;
        Boolean DivisonM = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "0";
        }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "1";
        }

        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "2";
        }

        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "3";
        }

        private void Num4_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "4";
        }

        private void Num5_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "5";
        }

        private void Num6_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "6";
        }

        private void Num7_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "7";
        }

        private void Num8_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "8";
        }

        private void Num9_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = Math.Content + "9";
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Math.Content = "";
            AdditionM = false;
            SubtractionM = false;
            MultiplicationM = false;
            DivisonM = false;
        }

        private void Reverse_Click(object sender, RoutedEventArgs e)
        {
            if(Math.Content.ToString().Length >= 1)
            {
                Math.Content = Math.Content.ToString().Remove(Math.Content.ToString().Length - 1);
            }
        }

        private void Addition_Click(object sender, RoutedEventArgs e)
        {
            firstNum = double.Parse(Math.Content.ToString());
            AdditionM = true;
            Math.Content = "";
        }

        private void Subtracion_Click(object sender, RoutedEventArgs e)
        {
            firstNum = double.Parse(Math.Content.ToString());
            SubtractionM = true;
            Math.Content = "";
        }

        private void Multiplication_Click(object sender, RoutedEventArgs e)
        {
            firstNum = double.Parse(Math.Content.ToString());
            MultiplicationM = true;
            Math.Content = "";
        }

        private void Division_Click(object sender, RoutedEventArgs e)
        {
            firstNum = double.Parse(Math.Content.ToString());
            DivisonM = true;
            Math.Content = "";
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            secondNum = double.Parse(Math.Content.ToString());

            if (AdditionM)
            {
                Math.Content = (firstNum + secondNum);
                AdditionM = false;
            }
            else if (SubtractionM)
            {
                Math.Content = (firstNum - secondNum);
                SubtractionM = false;
            }
            else if (MultiplicationM)
            {
                Math.Content = (double) (firstNum * secondNum);
                MultiplicationM = false;
            }
            else if (DivisonM)
            {
                Math.Content = (double) (firstNum / secondNum);
                DivisonM = false;
            }
        }
    }
}
