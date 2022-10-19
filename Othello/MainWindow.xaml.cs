using OthelloPresentation.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace Othello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public GameWindowViewModel ViewModel { get; private set; } = new GameWindowViewModel();
        public ObservableCollection<ObservableCollection<Brush>> Board { get; private set; } = new();

        private ICommand? _placeDiskCommand;
        public ICommand ChangeColorCmd =>
        _placeDiskCommand ??= new PlaceDiskCommand();

        public MainWindow()
        {
            InitializeComponent();
            for (int row = 0; row < 8; ++row)
            {
                Board.Add(new ObservableCollection<Brush>());
                for (int col = 0; col < 8; ++col)
                {
                    Board[row].Add(Brushes.Green);
                }
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(gGameBoard);
            if (p.X > 60 && p.Y > 60)
            {

                double y = Math.Floor(Math.Ceiling(p.Y) / 60);
                double x = Math.Floor(Math.Ceiling(p.X) / 60);

                if (x >= 1) x -= 1;
                if (y >= 1) y -= 1;

                Board[(int)y][(int)x] = Brushes.White;
            }
        }
    }
}
