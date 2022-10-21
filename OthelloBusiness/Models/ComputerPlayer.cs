namespace OthelloBusiness.Models
{
    public class ComputerPlayer : Player
    {
        private Random random;
        public ComputerPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
            random = new Random();
        }

        public async override Task<Position> RequestMoveAsync(Disk[,] gameBoard, List<Position> validMoves)
        {
            return await Task.Run(() =>
            {
                Position? position = null;
                lock (threadLock)
                {
                    Thread.Sleep(2000);
                    Monitor.Wait(threadLock);
                    foreach (Position move in validMoves)
                    {
                        if ((move.Y == 0 && move.X == 0) || (move.Y == 0 && move.X == 7) || (move.Y == 7 && move.X == 0) || (move.Y == 7 && move.X == 7))
                        {
                            position = move;
                            break;
                        }
                    }
                    if (position == null) position = validMoves[random.Next(validMoves.Count)];

                    Monitor.PulseAll(threadLock);
                }
                return position;
            });
        }
    }
}
