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
            //lock (threadLock)
            //{
            //    Monitor.Wait(threadLock);
            return await Task.Run(() =>
            {
                lock (threadLock)
                {
                    //while (X == -1)
                    //waitHandle.WaitOne();
                    //Thread.Sleep(1000);
                    Monitor.Wait(threadLock);
                    foreach (Position p in validMoves)
                    {
                        if (p.Y == Y && p.X == X)
                        {
                            pos = p;
                            Monitor.Pulse(threadLock);
                            break;
                        }
                    }
                    Monitor.PulseAll(pos);
                }
                return pos;


                //}
            });
        }
    }
}
