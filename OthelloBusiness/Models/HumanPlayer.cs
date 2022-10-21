namespace OthelloBusiness.Models
{
    public class HumanPlayer : Player
    {
        public int X { get; set; }
        public int Y { get; set; }

        public HumanPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
        }

        public async override Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves)
        {
            return await Task.Run(() =>
            {
                Position point = new();
                lock (threadLock)
                {
                    //Monitor.Wait(threadLock);

                    point.X = X;
                    point.Y = Y;

                    Monitor.PulseAll(threadLock);
                }
                return point;
            });
        }
    }
}
