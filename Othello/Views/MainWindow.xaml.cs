using OthelloBusiness.Controller;
using OthelloBusiness.Models;
using OthelloPresentation.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading;
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
        private Player? player1;
        private Player? player2;
        private GameManager gameManager;

        private ICommand? _placeDiskCommand;
        public ICommand PlaceDiskCmd =>
        _placeDiskCommand ??= new PlaceDiskCommand();

        private ICommand? _newGameCommand;
        public ICommand NewGameCmd =>
        _newGameCommand ??= new NewGameCommand();

        private ICommand? _gameExitCommand;
        public ICommand GameExitCmd =>
        _gameExitCommand ??= new GameExitCommand();

        private ICommand? _startGameCommand;
        public ICommand StartGameCmd =>
        _startGameCommand ??= new StartGameCommand();
        //public GameWindowViewModel ViewModel { get; private set; } = new GameWindowViewModel();
        public ObservableCollection<ObservableCollection<Brush>> Board { get; private set; }

        public MainWindow()
        {
            //DataContext = ViewModel;
            InitializeComponent();
            gameManager = new GameManager(player1, player2);
            Board = new ObservableCollection<ObservableCollection<Brush>>();
            for (int row = 0; row < 8; ++row)
            {
                Board.Add(new ObservableCollection<Brush>());
                for (int col = 0; col < 8; ++col)
                {
                    Board[row].Add(Brushes.Green);
                }
            }
            Play();

            //App.Current.Dispatcher.Invoke(() =>
            //{
            //    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
            //});
        }
        void Play()
        {
            while (true)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
                    Thread.Sleep(50);
                    UpdateGameBoard();
                });
            }
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

        private void UpdateGameBoard()
        {
            for (int y = 0; y < gameManager.gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < gameManager.gameBoard.GetLength(1); x++)
                {
                    if (Disk.WHITE == gameManager.gameBoard[y, x])
                    {
                        Board[y][x] = Brushes.White;

                    }
                    else if (Disk.BLACK == gameManager.gameBoard[y, x])
                    {
                        Board[y][x] = Brushes.Black;
                    }
                }
            }
        }
    }
}
