using System.Windows;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for WinnerDialog.xaml
    /// </summary>
    public partial class WinnerDialog : Window
    {
        public string? WinnerMessage { get; set; } = "";
        public WinnerDialog()
        {
            InitializeComponent();
        }
    }
}
