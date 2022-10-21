using OthelloBusiness.Models;

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

        private GameBoard? board;
        //private Thread computerThread;


        public GameManager(Player player1, Player player2)
        {
            board = new GameBoard();
            this.player1 = player1;
            this.player2 = player2;
            gameBoard[3, 3] = Disk.WHITE;
            gameBoard[3, 4] = Disk.BLACK;
            gameBoard[4, 3] = Disk.BLACK;
            gameBoard[4, 4] = Disk.WHITE;
            //computerThread = new Thread(Play);
            //computerThread.Start();
            //computerThread.Name = "computerThread";
        }

        public async void Play()
        {
            //lock (board)
            //{
            //    Monitor.PulseAll(board);

            //    Monitor.Wait(board);

            //try
            //{
            player = player1;
            while (isPlaying)
            {

                // Nedan används för att växla till gui tråden. alltså primärtråden.
                //App.Current.Dispatcher.Invoke(() =>
                //{
                //    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
                //});
                int numOfChanges = 0;


                validMoves = board.ValidMoves(player, gameBoard);
                if (validMoves.Count == 0) skippedRounds++;
                else
                {
                    //await Task.Run(async () =>
                    //{
                    Position position = await player.RequestMoveAsync(gameBoard, validMoves);

                    gameBoard = await board.MakeMoveAsync(position, gameBoard, player);
                    //});
                    //numOfChanges = board.MakeMove(player, move[0], move[1], gameBoard);
                    //player.numOfDisks += numOfChanges + 1;
                    numOfChanges = player.numOfChanges;
                    skippedRounds = 0;
                }
                player = player2.Name == player.Name ? player1 : player2;
                player.numOfDisks -= numOfChanges;
                if (skippedRounds == 2) break;

            }
            //Monitor.PulseAll(board);
            //Stop();

            //if (player1.numOfDisks == player2.numOfDisks)
            //{

            //}
            //else
            //{

            //}

            //}
            //catch (ThreadInterruptedException)
            //{
            //    Console.WriteLine("Computer player is done.");
            //}
            //}
        }

        //public void Stop()
        //{
        //    computerThread.Interrupt();
        //}
    }
}
