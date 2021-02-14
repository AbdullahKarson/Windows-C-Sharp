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
    /// Interaction logic for Incrementer.xaml
    /// </summary>
    public partial class Incrementer : UserControl
    {
        public event EventHandler IncrementMe;

        public Incrementer()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (this.IncrementMe != null)
                this.IncrementMe(this, e);
        }
    }
}
