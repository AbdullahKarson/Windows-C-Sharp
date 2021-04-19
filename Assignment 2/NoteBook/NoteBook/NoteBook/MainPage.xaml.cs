using NoteBook.Repo;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NoteBook
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ViewModels.NoteFileViewModel NoteFileViewModel { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            this.NoteFileViewModel = new ViewModels.NoteFileViewModel(fileText);
            DBNoteBook.CreateDB();
        }

        private void About_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AboutPage));
        }
    }
}
