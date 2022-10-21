namespace OthelloConsole.Models
{
    public abstract class Player
    {
        /*
         * Se över synlighet!
         */
        //protected Player player;

        public int numOfDisks = 2;
        public int numOfChanges = 0;
        public int disksPlaced = 30;

        public string? Name { get; set; }

        public Disk Disk { get; set; }


        public abstract Point RequestMove(Disk[,] gameBoard, List<Point> validMoves);
        //{
        //Inhämta Player Name från SetupGameDialog och WinnerDialog
        //}
    }
}
