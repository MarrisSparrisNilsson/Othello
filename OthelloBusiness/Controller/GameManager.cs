using OthelloBusiness.Models;

namespace OthelloBusiness.Controller
{
    public class GameManager
    {
        public int skippedRounds { get; set; }

        private Player player1;
        private Player player2;
        private bool isPlaying = true;
        private Disk[,] gameBoard = new Disk[8, 8];
        private List<Point>? validMoves;
        private GameBoard board;
        private int roundCount = 1;
        //private Thread computerThread;
        private Player player;


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
        //public void Start()
        //{
        //    if (thread == null)
        //    {
        //        // Create and run the client's communication on a new thread,
        //        // with the Run() method as the thread's entry point.
        //        thread = new Thread(Run);
        //        thread.IsBackground = true;
        //        thread.Start();
        //    }
        //}
        public async void Play()
        {


            //lock (board)
            //{
            //    Monitor.PulseAll(board);

            //    Monitor.Wait(board);

            //try
            //{
            player = player1;
            Console.WriteLine("Round: 0");
            while (isPlaying)
            {

                // Nedan används för att växla till gui tråden. alltså primärtråden.
                //App.Current.Dispatcher.Invoke(() =>
                //{
                //    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
                //});
                if (roundCount + 1 != 62)
                {
                    ShowGameBoard();
                    ShowRoundInfo();
                }
                int numOfChanges = 0;

                // player.GetName() ?
                // player.GetDisk() ?
                // Synlighet?
                validMoves = board.ValidMoves(player, ref gameBoard);
                if (validMoves.Count == 0) skippedRounds++;
                else
                {
                    gameBoard = await player.RequestMoveAsync(gameBoard, validMoves);
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
            //Stop(); // varför funkar ej detta?
            if (player1.numOfDisks == player2.numOfDisks)
            {
                ShowGameBoard();
                Console.WriteLine("The game ended with a draw!");
            }

            else
            {
                ShowGameBoard();
                ShowEndGameMessage();
            }
            //}
            //catch (ThreadInterruptedException)
            //{
            //    Console.WriteLine("Computer player is done.");
            //}
            //}
        }
        private void ShowGameBoard()
        {
            for (int y = 0; y < gameBoard.GetLength(0); y++)
            {
                Console.WriteLine();
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {

                    if (gameBoard[y, x] == Disk.BLANK)
                    {
                        Console.Write("0 ");
                    }
                    else if (gameBoard[y, x] == Disk.BLACK)
                    {
                        Console.Write("B ");
                    }
                    else
                    {
                        Console.Write("W ");
                    }
                }
            }
            Console.WriteLine("\n");
        }

        private void ShowEndGameMessage()
        {
            Console.WriteLine($"\n{player1.Name} got: {player1.numOfDisks} disks!");
            Console.WriteLine($"{player2.Name} got: {player2.numOfDisks} disks!");
            Console.WriteLine(
                $"Congratulations " +
                $"{(player1.numOfDisks > player2.numOfDisks ? player1.Name : player2.Name)}" +
                $" won the game of Othello!");
        }

        private void ShowRoundInfo()
        {
            Console.WriteLine($"{player1.Disk}: {player1.numOfDisks}");
            Console.WriteLine($"{player2.Disk}: {player2.numOfDisks}");
            Console.WriteLine($"\nRound: {roundCount++}");
            Console.WriteLine(player.Name + " - " + player.Disk);
        }
        //public void Stop()
        //{
        //    computerThread.Interrupt();
        //}
    }
}
