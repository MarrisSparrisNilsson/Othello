using OthelloBusiness.Controller;
using OthelloBusiness.Models;
using OthelloPresentation.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window, INotifyPropertyChanged
    {
        public static GameManager? _GameManager { get; set; }

        private ICommand? _newGameCommand;
        public ICommand NewGameCmd =>
        _newGameCommand ??= new NewGameCommand();

        private ICommand? _gameExitCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand GameExitCmd =>
        _gameExitCommand ??= new GameExitCommand();

        private int roundNum;

        public int RoundNum
        {
            get { return roundNum; }
            set
            {
                roundNum = value;
                OnPropertyChanged();
            }
        }

        private string whiteName;
        private string blackName;

        public string WhiteName
        {
            get { return whiteName; }
            set
            {
                whiteName = value;
                OnPropertyChanged();
            }
        }
        public string BlackName
        {
            get { return blackName; }
            set
            {
                blackName = value;
                OnPropertyChanged();
            }
        }

        private int wScore = 0;
        private int bScore = 0;

        public int WhiteScore
        {
            get { return wScore; }
            set
            {
                wScore = value;
                OnPropertyChanged();
            }
        }
        public int BlackScore
        {
            get { return bScore; }
            set
            {
                bScore = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public GameWindow()
        {
            InitializeComponent();
        }

        public void StartGame(Player blackPlayer, Player whitePlayer)
        {
            BlackName = blackPlayer.Name;
            BlackScore = bScore;

            WhiteName = whitePlayer.Name;
            WhiteScore = wScore;

            GameGrid grid = new GameGrid();
            _GameManager = new GameManager(blackPlayer, whitePlayer, this.UpdateGameStats, grid.UpdateGameBoard, this.ShowEndGameDialog);
            _GameManager.Play();
        }

        public void UpdateGameStats(int round, Player blackPlayer, Player whitePlayer)
        {
            if (RoundNum + 1 != 62) RoundNum = round;
            BlackScore = blackPlayer.numOfDisks;
            WhiteScore = whitePlayer.numOfDisks;
        }

        public void ShowEndGameDialog(Player blackPlayer, Player whitePlayer)
        {
            if (blackPlayer.numOfDisks == whitePlayer.numOfDisks)
            {
                DrawnDialog drawnDialog = new DrawnDialog();
                drawnDialog.ShowDialog();
            }
            else
            {
                WinnerDialog winnerDialog = new WinnerDialog();
                winnerDialog.WinnerMessage = ((blackPlayer.numOfDisks > whitePlayer.numOfDisks) ? blackPlayer.Name : whitePlayer.Name) + " Wins!";
                winnerDialog.ShowDialog();
            }
        }
    }
}
