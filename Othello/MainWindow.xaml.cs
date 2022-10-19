using OthelloPresentation.ViewModels;
using System.Windows;

namespace Othello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameWindowViewModel ViewModel { get; private set; } = new GameWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
