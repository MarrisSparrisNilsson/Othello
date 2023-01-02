namespace OthelloBusiness.Models
{
    public class HumanPlayer : Player
    {
        public int X { get; set; } = -1;
        public int Y { get; set; }

        public HumanPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
        }

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