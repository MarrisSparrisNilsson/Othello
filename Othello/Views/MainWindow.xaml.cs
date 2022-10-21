using OthelloBusiness.Controller;
using OthelloBusiness.Models;
using OthelloPresentation.Commands;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Point = OthelloBusiness.Models.Point;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static GameManager? _GameManager { get; set; }

        private ICommand? _newGameCommand;
        public ICommand NewGameCmd =>
        _newGameCommand ??= new NewGameCommand();

        private ICommand? _gameExitCommand;
        public ICommand GameExitCmd =>
        _gameExitCommand ??= new GameExitCommand();

        //public GameWindowViewModel ViewModel { get; private set; } = new GameWindowViewModel();

        /*
        * Ha denna bara i GameGrid?
        * MainWindow updaterar inte längre spelbrädet.
        */

        /*
        * MainWindow ska innehålla:
        1. GameGrid instans
        2. New Game -> SetupGameDialog
        3. Exit Game -> Environment.Exit(0);
        4. Presenterar game status         
         */

        public MainWindow()
        {
            InitializeComponent();
            while (true)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
                    Thread.Sleep(50);
                    UpdateGameBoard();
                    Thread.Sleep(50);
                    foreach (Point point in _GameManager.validMoves)
                    {
                        GameGrid.Board[(int)point.Y][(int)point.X] = Brushes.LightGray;
                    }
                });

                //Tanken var att skapa gråa rutor för varje valid move

                if (_GameManager.skippedRounds == 2)
                {
                    if (_GameManager.player1.numOfDisks == _GameManager.player2.numOfDisks)
                    {
                        DrawnDialog drawnDialog = new DrawnDialog();
                        drawnDialog.ShowDialog();
                    }
                    else
                    {
                        WinnerDialog winnerDialog = new WinnerDialog();
                        winnerDialog.WinnerMessage = ((_GameManager.player1.numOfDisks > _GameManager.player2.numOfDisks) ? _GameManager.player1.Name : _GameManager.player2.Name) + "wins!";
                        winnerDialog.ShowDialog();
                    }
                }
            }
        }

        private void UpdateGameBoard()
        {
            for (int y = 0; y < _GameManager.gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < _GameManager.gameBoard.GetLength(1); x++)
                {
                    if (Disk.WHITE == _GameManager.gameBoard[y, x])
                    {
                        GameGrid.Board[y][x] = Brushes.White;

                    }
                    else if (Disk.BLACK == _GameManager.gameBoard[y, x])
                    {
                        GameGrid.Board[y][x] = Brushes.Black;
                    }
                    else GameGrid.Board[y][x] = Brushes.Green;
                }
            }
        }
    }
}
