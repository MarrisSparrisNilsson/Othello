namespace OthelloBusiness.Models
{
    public abstract class Player
    {
        public static AutoResetEvent waitHandle = new AutoResetEvent(false);

        protected object? threadLock = new object();

        public int numOfDisks = 2;
        public int numOfChanges = 0;
        public int disksPlaced = 30;

        public string? Name { get; set; }

        public Disk Disk { get; set; }


        public abstract Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves);

        public virtual void SetMove(int x, int y) { }

    }
}