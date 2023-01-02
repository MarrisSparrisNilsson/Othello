﻿using OthelloBusiness.Models;

namespace OthelloBusiness.Controller
{
    public class GameManager
    {
        public int skippedRounds;

        public Player? player;
        public Player? player1;
        public Player? player2;

        private bool isPlaying = true;
        public Disk[,]? gameBoard = new Disk[8, 8];
        public List<Position>? validMoves;
        private Action<Disk[,], List<Position>> notifyGameBoardChanged;

        private GameBoard? board;

        public GameManager(Player player1, Player player2)
        {
            board = new GameBoard();
            this.player1 = player1;
            this.player2 = player2;
            gameBoard[3, 3] = Disk.WHITE;
            gameBoard[3, 4] = Disk.BLACK;
            gameBoard[4, 3] = Disk.BLACK;
            gameBoard[4, 4] = Disk.WHITE;
        }

        public GameManager(Player player1, Player player2, Action<Disk[,], List<Position>> notifyGameBoardChanged)
        {
            this.notifyGameBoardChanged = notifyGameBoardChanged;
        }
        public async void Play()
        {
            player = player1;
            while (isPlaying)
            {
                int numOfChanges = 0;

                validMoves = board.ValidMoves(player, gameBoard);
                if (validMoves.Count == 0) skippedRounds++;
                else
                {
                    Position position = await player.RequestMoveAsync(gameBoard, validMoves);
                    gameBoard = await board.MakeMoveAsync(position, gameBoard, player);
                    //numOfChanges = board.MakeMove(player, move[0], move[1], gameBoard);
                    //player.numOfDisks += numOfChanges + 1;
                    numOfChanges = player.numOfChanges;
                    skippedRounds = 0;
                }
                player = player2.Name == player.Name ? player1 : player2;
                player.numOfDisks -= numOfChanges;
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
                        gameBoardCopy[row, col] = gameBoard[row, col];
                List<Position> validMoves = board.ValidMoves(player, gameBoard);
                notifyGameBoardChanged(gameBoardCopy, validMoves);
            }
        }
    }
}
