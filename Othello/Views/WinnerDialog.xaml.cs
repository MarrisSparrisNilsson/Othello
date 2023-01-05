using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for WinnerDialog.xaml
    /// </summary>
    public partial class WinnerDialog : Window, INotifyPropertyChanged
    {
        private string? winnerMessage = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        public string? WinnerMessage
        {
            get { return winnerMessage; }
            set
            {
                winnerMessage = value;
                OnPropertyChanged();
            }
        }
        public WinnerDialog()
        {
            InitializeComponent();
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
