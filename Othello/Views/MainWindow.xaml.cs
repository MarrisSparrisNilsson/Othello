using OthelloPresentation.Commands;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Point = System.Windows.Point;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICommand? _placeDiskCommand;
        public ICommand PlaceDiskCmd =>
        _placeDiskCommand ??= new PlaceDiskCommand();

        private ICommand? _gameExitCommand;
        public ICommand GameExitCmd =>
        _gameExitCommand ??= new GameExitCommand();
        //public GameWindowViewModel ViewModel { get; private set; } = new GameWindowViewModel();
        public ObservableCollection<ObservableCollection<Brush>> Board { get; private set; } = new();

        public MainWindow()
        {
            //DataContext = ViewModel;
            InitializeComponent();
            for (int row = 0; row < 8; ++row)
            {
                Board.Add(new ObservableCollection<Brush>());
                for (int col = 0; col < 8; ++col)
                {
                    Board[row].Add(Brushes.Green);
                }
            }
            //App.Current.Dispatcher.Invoke(() =>
            //{
            //    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
            //});
            Board[3][3] = Brushes.White;
            Board[3][4] = Brushes.Black;
            Board[4][3] = Brushes.Black;
            Board[4][4] = Brushes.White;

        }
        // På något sätt behöver vi också när validMoves returnerar uppdatera guit och färglägga alla punkter i guit i grått.
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(gGameBoard);
            // Vi måste typ ha en if sats eller liknande som först kollar att den point som tryckts på matchar en punkt i valid moves.
            if (p.X > 60 && p.Y > 60)
            {

                double y = Math.Floor(Math.Ceiling((double)p.Y) / 60);
                double x = Math.Floor(Math.Ceiling((double)p.X) / 60);

                if (x >= 1) x -= 1;
                if (y >= 1) y -= 1;

                Board[(int)y][(int)x] = Brushes.White;
            }
        }
    }
}
