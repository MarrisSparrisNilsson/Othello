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
    /// Interaktionslogik för GameWindow.xaml
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

        private string? currentPlayer;

        public string? CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                currentPlayer = value;
                OnPropertyChanged();
            }
        }

        private string? whiteName;
        private string? blackName;

        public string? WhiteName
        {
            get { return whiteName; }
            set
            {
                whiteName = value;
                OnPropertyChanged();
            }
        }
        public string? BlackName
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

        /// <summary>
        /// Metod för att notifiera GUIt om att en property's värde har ändrats
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public GameWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Startar ett spel genom att anropa Play metoden i GameManager och sätter start konfiguration till GUI element.
        /// </summary>
        /// <param name="blackPlayer" name="whitePlayer">
        /// Parametern blackPlayer innehåller information om den svarta spelaren.
        /// Parametern whitekPlayer innehåller information om den vita spelaren.
        /// </param>
        public void StartGame(Player blackPlayer, Player whitePlayer)
        {
            BlackName = blackPlayer.Name;
            BlackScore = bScore;

            WhiteName = whitePlayer.Name;
            WhiteScore = wScore;

            RoundNum = 0;

            _GameManager = new GameManager(blackPlayer, whitePlayer, grid.UpdateGameBoard, this.UpdateGameStats, this.ShowEndGameDialog);
            _GameManager.Play();
        }

        /// <summary>
        /// Updaterar GUI komponenter med numret på den aktuella rundan och spelarnas poäng.
        /// </summary>
        /// <param name="round" name="blackPlayer" name="whitePlayer" name="currentDiskColor">
        /// Parametern round innehåller numret på den nya rundan.
        /// Parametern blackPlayer innehåller information om den svarta spelaren.
        /// Parametern whitekPlayer innehåller information om den vita spelaren.
        /// Parametern currentDiskColor representerar färgen på brickan som tillhör spelaren som härnäst ska utföra sitt drag.
        /// </param>
        public void UpdateGameStats(int round, Player blackPlayer, Player whitePlayer, Disk currentDiskColor)
        {
            if (RoundNum + 1 != 62) RoundNum = round;
            BlackScore = blackPlayer.numOfDisks;
            WhiteScore = whitePlayer.numOfDisks;

            CurrentPlayer = $"{(currentDiskColor == Disk.BLACK ? $"{blackPlayer.Name}" : $"{whitePlayer.Name}")} is playing...";

        }

        /// <summary>
        /// Beroende på poängen för de båda spelarna så visas olika dialoger.
        /// Om poängen är lika visas DrawnDialog som talar om att spelet blivit oavgjort
        /// Om någon spelare har fler än den andre så visas en WinnerDialog som talar om vilken spelare som har vunnit.
        /// </summary>
        /// <param name="blackPlayer" name="whitePlayer">
        /// Parametern blackPlayer innehåller information om den svarta spelaren.
        /// Parametern whitekPlayer innehåller information om den vita spelaren.
        /// </param>
        public void ShowEndGameDialog(Player blackPlayer, Player whitePlayer)
        {
            CurrentPlayer = "";
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
