namespace OthelloBusiness.Models
{
    // <summary>
    /// Beskriv metoden h ̈ar
    /// </summary>
    /// <param name="paramname"> Beskriv parameter h ̈ar </param>
    /// <returns> Beskriv returv ̈ardet h ̈ar </returns>
    public abstract class Player
    {
        protected object? threadLock = new object();

        public int numOfDisks = 2;
        public int numOfChanges = 0;

        public string? Name { get; set; }

        public Disk Disk { get; set; }

        // <summary>
        /// Beskriv metoden h ̈ar
        /// </summary>
        /// <param name="paramname"> Beskriv parameter h ̈ar </param>
        /// <returns> Beskriv returv ̈ardet h ̈ar </returns>
        public abstract Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves);

        // <summary>
        /// Beskriv metoden h ̈ar
        /// </summary>
        /// <param name="paramname"> Beskriv parameter h ̈ar </param>
        /// <returns> Beskriv returv ̈ardet h ̈ar </returns>
        public virtual void SetMove(int x, int y) { }
    }
}