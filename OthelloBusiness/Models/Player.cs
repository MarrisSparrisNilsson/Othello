namespace OthelloBusiness.Models
{
    public abstract class Player
    {
        /*
         * Se över synlighet!
         */

        public int numOfDisks = 2;

        public string? Name { get; set; }

        public Disk Disk { get; set; }


        public abstract int RequestMove(ref Disk[,] gameBoard, List<Point> validMoves);
        //{
        //Inhämta Player Name från SetupGameDialog och WinnerDialog
        //}
        public abstract int MakeMove(int y, int x, ref Disk[,] gameBoard, List<Point> validMoves);
    }
}
