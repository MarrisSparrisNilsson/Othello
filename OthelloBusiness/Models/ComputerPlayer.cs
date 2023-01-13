namespace OthelloBusiness.Models
{
    /// <summary>
    /// Denna klass representerar en datorspelare
    /// </summary>
    public class ComputerPlayer : Player
    {
        private Random? random;

        public ComputerPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
            random = new Random();
        }

        /// <summary>
        /// RequestMoveAsync är en asynkron metoed som ber om att få utföra ett drag bland de möjliga dragen som är listade i validMoves
        /// </summary>
        /// <param name="gameBoard" name="validMoves">
        /// Parametern gameBoard innehåller spelbrädets aktuella tillstånd.
        /// Parametern validMoves innehåller de möjliga dragen som spelaren kan göra utifrån spelbrädets aktuella tillstånd.
        /// </param>
        /// <returns>Det som returneras är den postition på spelbrädet som spelaren har valt att lägga brickan på</returns>
        public async override Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves)
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(1000);
                Position? position = null;
                foreach (Position move in validMoves)
                {
                    if ((move.Y == 0 && move.X == 0) || (move.Y == 0 && move.X == 7) || (move.Y == 7 && move.X == 0) || (move.Y == 7 && move.X == 7))
                    {
                        position = move;
                        break;
                    }
                }
                if (position == null) position = validMoves[random.Next(validMoves.Count)];
                return position;
            });
        }
    }
}