namespace OthelloBusiness.Models
{
    public abstract class Player
    {
        /*
         * Se över synlighet!
         */
        //protected Player player;
        protected object? threadLock = new object();

        public int numOfDisks = 2;
        public int numOfChanges = 0;
        public int disksPlaced = 30;

        public string? Name { get; set; }

        public Disk Disk { get; set; }


        public abstract Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves);
        //{
        //Inhämta Player Name från SetupGameDialog och WinnerDialog
        //}
    }
}
