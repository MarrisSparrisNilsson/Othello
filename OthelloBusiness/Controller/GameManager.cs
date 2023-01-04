using OthelloBusiness.Models;

namespace OthelloBusiness.Controller
{
    public class GameManager
    {
        public int skippedRounds;
        private int round = 1;

        public Player? player;
        public Player? blackPlayer;
        public Player? whitePlayer;

        private bool isPlaying = true;
        //public Disk[,]? gameBoard = new Disk[8, 8];
        public List<Position>? validMoves;
        private Action<Disk[,], List<Position>> notifyGameBoardChanged;
        private Action<int, Player, Player> notifyGameStatsChanged;

        private GameBoard? board;

        //public GameManager(Player blackPlayer, Player whitePlayer, GameBoard grid)
        //{
        //    board = grid;


        //}

        public GameManager(
            Player blackPlayer,
            Player whitePlayer,
            Action<int, Player, Player> notifyGameStatsChanged,
            Action<Disk[,], List<Position>> notifyGameBoardChanged)
        {
            board = new GameBoard();
            this.blackPlayer = blackPlayer;
            this.whitePlayer = whitePlayer;

            this.notifyGameBoardChanged = notifyGameBoardChanged;
            this.notifyGameStatsChanged = notifyGameStatsChanged;
        }

        public async void Play()
        {
            player = blackPlayer;
            UpdateObservers();
            while (isPlaying)
            {
                int numOfChanges = 0;

                validMoves = board.ValidMoves(player, board.gameBoard);
                if (validMoves.Count == 0) skippedRounds++;
                else
                {
                    Position position = await player.RequestMoveAsync(board.gameBoard, validMoves);
                    board.gameBoard = await board.MakeMoveAsync(position, board.gameBoard, player);
                    //numOfChanges = board.MakeMove(player, move[0], move[1], gameBoard);
                    //player.numOfDisks += numOfChanges + 1;
                    numOfChanges = player.numOfChanges;
                    skippedRounds = 0;
                }
                player = whitePlayer.Name == player.Name ? blackPlayer : whitePlayer;
                player.numOfDisks -= numOfChanges;
                round++;
                UpdateObservers();
                if (skippedRounds == 2) break;
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
                notifyGameStatsChanged(round, blackPlayer, whitePlayer);
            }
        }
    }
}
