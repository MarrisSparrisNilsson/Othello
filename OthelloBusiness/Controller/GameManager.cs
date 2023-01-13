using OthelloBusiness.Models;

namespace OthelloBusiness.Controller
{
    /// <summary>
    /// GameManager är klassen som det pågående spelet Othello. Gång på gång tillåter den båda spelarna att utföra sin runda och håller 
    /// samtidigt reda på spelets tillstånd.
    /// </summary>
    public class GameManager
    {
        private int round = 1;

        private Player? player;
        private Player? blackPlayer;
        private Player? whitePlayer;

        private List<Position>? validMoves;
        private Action<Disk[,], List<Position>>? notifyGameBoardChanged;
        private Action<int, Player, Player, Disk>? notifyGameStatsChanged;
        private Action<Player, Player>? showEndGameDialog;

        private GameBoard? board;

        public GameManager(
            Player? blackPlayer,
            Player? whitePlayer,
            Action<Disk[,], List<Position>>? notifyGameBoardChanged,
            Action<int, Player, Player, Disk>? notifyGameStatsChanged,
            Action<Player, Player>? showEndGameDialog)
        {
            board = new GameBoard();
            this.blackPlayer = blackPlayer;
            this.whitePlayer = whitePlayer;
            this.notifyGameBoardChanged = notifyGameBoardChanged;
            this.notifyGameStatsChanged = notifyGameStatsChanged;
            this.showEndGameDialog = showEndGameDialog;
        }

        /// <summary>
        /// Play metoden startar spelet och tillåter gång på gång de båda spelarna att utföra sin runda.
        /// </summary>
        public async void Play()
        {
            int skippedRounds = 0;
            player = blackPlayer;
            UpdateObservers();
            while (true)
            {
                int numOfChanges = 0;

                validMoves = board.ValidMoves(player, board.gameBoard);
                if (validMoves.Count == 0) skippedRounds++;
                else
                {
                    Position position = await player.RequestMoveAsync(board.gameBoard, validMoves);
                    board.gameBoard = board.MakeMove(position, board.gameBoard, player);
                    numOfChanges = player.numOfChanges;
                    skippedRounds = 0;
                }
                player = whitePlayer.Name == player.Name ? blackPlayer : whitePlayer;
                player.numOfDisks -= numOfChanges;
                round++;
                UpdateObservers();
                if (skippedRounds == 2)
                {
                    showEndGameDialog(whitePlayer, blackPlayer);
                    break;
                }
            }
        }

        /// <summary>
        /// SetMove är metoden som gör det möjligt för HumanPlayer att göra sitt drag och efteråt göra så att spelet fortsätter sin exekvering efteråt.
        /// </summary>
        /// <param name="x" name="y"> 
        /// Parameter x representerar x-koordinaten som användaren valde att lägga sin bricka på spelbrädet.
        /// Parameter y representerar y-koordinaten som användaren valde att lägga sin bricka på spelbrädet.
        /// </param>
        public void SetMove(int x, int y)
        {
            player.SetMove(x, y);
        }

        /// <summary>
        /// UpdateObservers innehåller delegates vars uppgift är att skicka ny information 
        /// som skall visas i GUIt efter varje ändring som görs på spelbrädet.
        /// </summary>
        private void UpdateObservers()
        {
            if (notifyGameBoardChanged != null)
            {
                Disk[,] gameBoardCopy = new Disk[8, 8];
                for (int row = 0; row < 8; ++row)
                    for (int col = 0; col < 8; ++col)
                        gameBoardCopy[row, col] = board.gameBoard[row, col];
                List<Position> validMoves = board.ValidMoves(player, board.gameBoard);
                notifyGameBoardChanged(gameBoardCopy, validMoves);
                notifyGameStatsChanged(round, blackPlayer, whitePlayer, player.Disk);
            }
        }
    }
}
