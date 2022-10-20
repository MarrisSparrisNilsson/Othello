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

        public async override Task<Disk[,]> RequestMoveAsync(Disk[,] gameBoard, List<Point> validMoves)
        {
            return await Task.Run(() =>
            {
                Point? point = null;
                lock (threadLock)
                {
                    Monitor.Wait(threadLock);
                    Thread.Sleep(2000);
                    //Thread.CurrentThread.Name = "Martin";
                    int[] position = new int[2];
                    foreach (Point move in validMoves)
                    {
                        if ((move.Y == 0 && move.X == 0) || (move.Y == 0 && move.X == 7) || (move.Y == 7 && move.X == 0) || (move.Y == 7 && move.X == 7))
                        {
                            point = move;
                            break;
                        }
                    }
                    if (point == null) point = validMoves[random.Next(validMoves.Count)];
                    //if (position[0] != 0 && position[1] != 0 || position[0] != 7 && position[1] != 0 || position[0] != 0 && position[1] != 7 || position[0] != 7 && position[1] != 7)
                    //{
                    //}
                    Console.WriteLine($"{Name} placed a disk at position: ({position[0]}, {position[1]})");
                    Monitor.PulseAll(threadLock);
                }
                return MakeMove(point, gameBoard);
            });
        }

        public override Disk[,] MakeMove(Point point, Disk[,] gameBoard)
        {
            numOfChanges = 0;

            gameBoard[point.Y, point.X] = Disk;
            numOfDisks++;
            //foreach (Point pointItem in validMoves)
            //{
            //    if (pointItem.X == x && pointItem.Y == y)
            //    {
            for (int i = 0; i <= point.FlipPoints.Count - 2 || i == 0; i += 2)
            {
                gameBoard[point.FlipPoints[i], point.FlipPoints[i + 1]] = Disk;
                numOfChanges++;

            }
            //    }
            //}
            numOfDisks += numOfChanges;
            return gameBoard;
        }
    }
}
