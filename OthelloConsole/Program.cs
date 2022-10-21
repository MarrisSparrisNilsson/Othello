using OthelloConsole.Controller;
using OthelloConsole.Views;

namespace OthelloConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            SetupGameDialog setupGameDialog = new SetupGameDialog();

            GameManager gameManager = setupGameDialog.SetupGame();

            gameManager.Play();
        }

    }
}