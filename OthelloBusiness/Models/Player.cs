namespace OthelloBusiness.Models
{
    public abstract class Player
    {
        protected object? threadLock = new object();

        public int numOfDisks = 2;
        public int numOfChanges = 0;

        public string? Name { get; set; }

        public Disk Disk { get; set; }

        public abstract Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves);

        public virtual void SetMove(int x, int y) { }
    }
}