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
        private Thread computerThread;


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
        public void Play()
        {

            //lock (board)
            //{
            //    Monitor.PulseAll(board);

            //    Monitor.Wait(board);

            //try
            //{
            Player player = player1;
            while (isPlaying)
            {
                Console.WriteLine($"Round: {roundCount++}");
                int numOfChanges = 0;

                // player.GetName() ?
                // player.GetDisk() ?
                // Synlighet?
                Console.WriteLine(player.Name + " - " + player.Disk);
                validMoves = board.ValidMoves(player, ref gameBoard);
                if (validMoves.Count == 0)
                {
                    skippedRounds++;
                }
                else
                {
                    //Thread.Sleep(2000);
                    numOfChanges = player.RequestMove(ref gameBoard, validMoves);
                    //numOfChanges = board.MakeMove(player, move[0], move[1], ref gameBoard);
                    player.numOfDisks += numOfChanges + 1;
                    skippedRounds = 0;
                }
                if (skippedRounds == 2)
                {
                    isPlaying = false;
                    continue;
                }
                player = player2.Name == player.Name ? player1 : player2;
                player.numOfDisks -= numOfChanges;

                // Nedan används för att växla till gui tråden. alltså primärtråden.
                //App.Current.Dispatcher.Invoke(() =>
                //{
                //    // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
                //});

            }
            //Monitor.PulseAll(board);
            //Stop(); // varför funkar ej detta?
            if (player1.numOfDisks == player2.numOfDisks)
                Console.WriteLine("The game ended with a draw");
            else
            {
                Console.WriteLine($"\n{player1.Name} got: {player1.numOfDisks} disks!");
                Console.WriteLine($"{player2.Name} got: {player2.numOfDisks} disks!");
                Console.WriteLine(
                    $"Congratulations " +
                    $"{(player1.numOfDisks > player2.numOfDisks ? player1.Name : player2.Name)}" +
                    $" won the game of Othello!");
            }
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
