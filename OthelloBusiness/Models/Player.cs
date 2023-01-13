namespace OthelloBusiness.Models
{
    /// <summary>
    /// Denna klass är en förälderklass till HumanPlayer och ComputerPlayer
    /// </summary>
    public abstract class Player
    {
        protected object? threadLock = new object();

        public int numOfDisks = 2;
        public int numOfChanges = 0;

        public string? Name { get; set; }

        public Disk Disk { get; set; }

        /// <summary>
        /// Denna abstrakta metod används av båda spelarna ber om att få göra ett drag.
        /// </summary>
        /// <param name="gameBoard" name="validMoves">
        /// Parametern gameBoard innehåller spelbrädets aktuella tillstånd.
        /// Parametern validMoves innehåller de möjliga dragen som spelaren kan göra utifrån spelbrädets aktuella tillstånd.
        /// </param>
        /// <returns>Det som returneras är den postition på spelbrädet som spelaren har valt att lägga brickan på</returns>
        public abstract Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves);

        /// <summary>
        /// SetMove är metoden som gör det möjligt för HumanPlayer att göra sitt drag och efteråt göra så att 
        /// spelet fortsätter sin exekvering efteråt.
        /// </summary>
        /// <param name="x" name="y"> 
        /// Parameter x representerar x-koordinaten som användaren valde att lägga sin bricka på spelbrädet.
        /// Parameter y representerar y-koordinaten som användaren valde att lägga sin bricka på spelbrädet.
        /// </param>
        public virtual void SetMove(int x, int y) { }
    }
}