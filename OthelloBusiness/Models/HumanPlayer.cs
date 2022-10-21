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
                Position pos = new();
                lock (threadLock)
                {
                    Monitor.Wait(threadLock);
                    //Thread.Sleep(5000);
                    foreach (Position p in validMoves)
                    {
                        if (p.Y == Y && p.X == X)
                        {
                            pos = p;
                            break;
                        }
                    }


                    //Monitor.PulseAll(pos);
                }
                return pos;
            });
        }
    }
}
