namespace OthelloBusiness.Models
{
    /// <summary>
    /// Denna klass representerar en mänsklig spelare.
    /// </summary>
    public class HumanPlayer : Player
    {
        public int X { get; set; } = -1;
        public int Y { get; set; }

        public HumanPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
        }

        /// <summary>
        /// RequestMoveAsync är en asynkron metod som ber om att få utföra ett drag bland de giltiga dragen som är listade i validMoves listan.
        /// </summary>
        /// <param name="gameBoard" name="validMoves">
        /// Parametern gameBoard innehåller spelbrädets aktuella tillstånd.
        /// Parametern validMoves innehåller de möjliga dragen som spelaren kan göra utifrån spelbrädets aktuella tillstånd.
        /// </param>
        /// <returns>Det som returneras är den postition på spelbrädet som spelaren har valt att lägga brickan på</returns>
        public async override Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves)
        {
            Position pos = new();
            return await Task.Run(() =>
            {
                lock (threadLock)
                {
                    Monitor.Wait(threadLock);
                    pos.X = X;
                    pos.Y = Y;
                    foreach (Position p in validMoves)
                    {
                        if (p.Y == Y && p.X == X)
                        {
                            pos = p;
                            break;
                        }
                    }
                }
                return pos;
            });
        }

        /// <summary>
        /// SetMove är metoden som gör det möjligt för HumanPlayer att göra sitt drag och efteråt göra så att spelet fortsätter sin exekvering efteråt.
        /// </summary>
        /// <param name="x" name="y"> 
        /// Parameter x representerar x-koordinaten som användaren valde att lägga sin bricka på spelbrädet.
        /// Parameter y representerar y-koordinaten som användaren valde att lägga sin bricka på spelbrädet.
        /// </param>
        public override void SetMove(int x, int y)
        {
            lock (threadLock)
            {
                X = x;
                Y = y;
                Monitor.PulseAll(threadLock);
            }
        }
    }
}