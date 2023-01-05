using System.ComponentModel;

namespace OthelloPresentation.ViewModels
{
    public class GameWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public GameWindowViewModel()
        {
        }
    }
}