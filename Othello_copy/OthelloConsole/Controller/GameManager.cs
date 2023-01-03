using OthelloConsole.Models;

namespace OthelloConsole.Controller
{
    public class GameManager
    {
        private int skippedRounds;
        private Player? player1;
        private Player? player2;
        private bool isPlaying = true;
        public Disk[,]? gameBoard = new Disk[8, 8];
        public List<Position>? validMoves;
        private GameBoard? board;
        private int roundCount = 1;
        private Player? player;


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

        public void Play()
        {
            player = player1;
            Console.WriteLine("Round: 0");
            while (isPlaying)
            {
                if (roundCount + 1 != 62)
                {
                    ShowGameBoard();
                    ShowRoundInfo();
                }
                int numOfChanges = 0;
                validMoves = board.ValidMoves(player, gameBoard);

                if (validMoves.Count == 0) skippedRounds++;
                else
                {
                    Position point = player.RequestMove(gameBoard, validMoves);
                    gameBoard = board.MakeMove(point, gameBoard, player);

                    numOfChanges = player.numOfChanges;
                    skippedRounds = 0;
                }
                player = player2.Disk == player.Disk ? player1 : player2;
                player.numOfDisks -= numOfChanges;
                if (skippedRounds == 2) break;

            }

            if (player1.numOfDisks == player2.numOfDisks)
            {
                ShowGameBoard();
                Console.WriteLine("The game ended with a draw!");
                Console.WriteLine($"\n{player1.Name} got: {player1.numOfDisks} disks!");
                Console.WriteLine($"{player2.Name} got: {player2.numOfDisks} disks!");
            }
            else
            {
                ShowGameBoard();
                ShowEndGameMessage();
            }
        }
        private void ShowGameBoard()
        {
            Console.WriteLine();
            for (int y = 0; y < gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    if (gameBoard[y, x] == Disk.BLANK)
                        Console.BackgroundColor = ConsoleColor.Green;
                    else if (gameBoard[y, x] == Disk.BLACK)
                        Console.BackgroundColor = ConsoleColor.Black;
                    else
                        Console.BackgroundColor = ConsoleColor.White;

                    Console.Write("  ");

                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    if (x < gameBoard.GetLength(1) - 1)
                        Console.Write("  ");

                }
                Console.BackgroundColor = ConsoleColor.Black;
                if (y != gameBoard.GetLength(0) - 1)
                {
                    for (int x = 0; x < gameBoard.GetLength(1) * 2 - 1; x++)
                    {
                        if (x == 0) Console.Write("\n");
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.Write("  ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                //Console.WriteLine("\n");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n");
        }

        private void ShowEndGameMessage()
        {
            Console.WriteLine($"\n{player1.Name} got: {player1.numOfDisks} disks!");
            Console.WriteLine($"{player2.Name} got: {player2.numOfDisks} disks!");
            Console.WriteLine(
                $"Congratulations! " +
                $"{(player1.numOfDisks > player2.numOfDisks ? player1.Name : player2.Name)}" +
                $" won the game of Othello!");
        }

        private void ShowRoundInfo()
        {
            Console.WriteLine($"{player1.Disk}: {player1.numOfDisks}");
            Console.WriteLine($"{player2.Disk}: {player2.numOfDisks}");
            Console.WriteLine($"\nRound: {roundCount++}");
            //Console.WriteLine(player.Name + " - " + player.Disk);
            Console.Write(player.Name + " - ");

            if (player.Disk == Disk.WHITE)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            Console.Write(player.Disk);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine();
        }
    }
}
