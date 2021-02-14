using System;
using System.Collections.Generic;
using System.Text;
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
    /// Interaction logic for TagEditMenuControl.xaml
    /// </summary>
    public partial class TagEditMenuControl : UserControl
    {

        public event EventHandler OpenTagger;

        public TagEditMenuControl()
        {
            InitializeComponent();
        }

        private void TagEdit_Click(object sender, RoutedEventArgs e)
        {
            if (this.OpenTagger != null)
            {
                this.OpenTagger(this, e);
            }
        }
    }
}
