using OthelloBusiness.Models;

namespace OthelloBusiness.Controller
{
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
            Player blackPlayer,
            Player whitePlayer,
            Action<Disk[,], List<Position>> notifyGameBoardChanged,
            Action<int, Player, Player, Disk> notifyGameStatsChanged,
            Action<Player, Player> showEndGameDialog)
        {
            board = new GameBoard();
            this.blackPlayer = blackPlayer;
            this.whitePlayer = whitePlayer;
            this.notifyGameBoardChanged = notifyGameBoardChanged;
            this.notifyGameStatsChanged = notifyGameStatsChanged;
            this.showEndGameDialog = showEndGameDialog;
        }

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
                    board.gameBoard = board.MakeMoveAsync(position, board.gameBoard, player);
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

        public void SetMove(int x, int y)
        {
            player.SetMove(x, y);
        }

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
