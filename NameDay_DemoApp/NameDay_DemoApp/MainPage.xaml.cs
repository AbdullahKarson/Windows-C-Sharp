using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NameDay_DemoApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ViewModels.NameDaysViewModel NDViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            this.NDViewModel = new ViewModels.NameDaysViewModel();
        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("THE WEBCAM BUTTON WAS CLICKED!");
        }
    }
}
