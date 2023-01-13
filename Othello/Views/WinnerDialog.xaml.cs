using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaktionslogik för WinnerDialog.xaml
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

        /// <summary>
        /// Metod för att notifiera GUIt om att en property's värde har ändrats
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
