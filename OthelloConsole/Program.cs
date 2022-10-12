using OthelloBusiness.Controller;
using OthelloBusiness.Models;

namespace OthelloConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter first playername!");
            //string? player1 = Console.ReadLine();
            //Console.WriteLine("Please enter second playername!");
            //string? player2 = Console.ReadLine();
            //Console.WriteLine();

            //Player othelloPlayer1 = new HumanPlayer(player1, Disk.BLACK);
            //Player othelloPlayer2 = new HumanPlayer(player2, Disk.WHITE);
            Player othelloPlayer3 = new ComputerPlayer("Computer Player1", Disk.BLACK);
            Player othelloPlayer4 = new ComputerPlayer("Computer Player2", Disk.WHITE);

            //GameManager gameManger = new GameManager(othelloPlayer1, othelloPlayer2);
            GameManager gameManger = new GameManager(othelloPlayer3, othelloPlayer4);
            //GameManager gameManger = new GameManager(othelloPlayer1, othelloPlayer3);
            gameManger.Play();
        }
    }
}