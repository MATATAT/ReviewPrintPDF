using System.Windows;
using ReviewPrintPDF.Interface.ViewModel;

namespace ReviewPrintPDF.Interface
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

        	this.DataContext = new MainViewModel();
        }
    }
}