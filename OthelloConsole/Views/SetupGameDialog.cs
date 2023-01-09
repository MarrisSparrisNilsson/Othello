using OthelloConsole.Controller;
using OthelloConsole.Models;

namespace OthelloConsole.Views
{
    public class SetupGameDialog
    {

        private Player? othelloPlayer1 = null;
        private Player? othelloPlayer2 = null;

        public GameManager SetupGame()
        {
            string? player1;
            string? player2;

            Console.Write("Select player setup:\n" +
                "1. Player vs Player\n" +
                "2. Player vs Computer \n" +
                "3. Computer vs Computer\n" +
                "?: ");

            string? option;
            bool inValidOption = true;

            while (inValidOption)
            {
                option = Console.ReadLine();
                Console.WriteLine();
                inValidOption = false;

                switch (option)
                {
                    case "1":
                        Console.Write("Please enter player1's name: ");
                        player1 = Console.ReadLine();
                        Console.Write("Please enter player2's name: ");
                        player2 = Console.ReadLine();
                        Console.WriteLine();

                        othelloPlayer1 = new HumanPlayer(player1, Disk.BLACK);
                        othelloPlayer2 = new HumanPlayer(player2, Disk.WHITE);

                        break;
                    case "2":
                        Console.Write("Please enter player1's name: ");
                        player1 = Console.ReadLine();

                        othelloPlayer1 = new HumanPlayer(player1, Disk.BLACK);
                        othelloPlayer2 = new ComputerPlayer("Computer Player2", Disk.WHITE);
                        break;
                    case "3":
                        othelloPlayer1 = new ComputerPlayer("Computer Player1", Disk.BLACK);
                        othelloPlayer2 = new ComputerPlayer("Computer Player2", Disk.WHITE);
                        break;
                    default:
                        inValidOption = true;
                        Console.WriteLine("Please enter a valid option.");
                        break;
                }
            }

            GameManager gameManager = new GameManager(othelloPlayer1, othelloPlayer2);

            return gameManager;
        }
    }
}
