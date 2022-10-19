
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

                Thread.Sleep(2000);
                //Thread.CurrentThread.Name = "Martin";
                int[] position = new int[2];
                foreach (Point move in validMoves)
                {
                    if ((move.Y == 0 && move.X == 0) || (move.Y == 0 && move.X == 7) || (move.Y == 7 && move.X == 0) || (move.Y == 7 && move.X == 7))
                    {
                        position[0] = move.Y;
                        position[1] = move.X;
                        break;
                    }
                }
                if (position[0] != 0 && position[1] != 0 || position[0] != 7 && position[1] != 0 || position[0] != 0 && position[1] != 7 || position[0] != 7 && position[1] != 7)
                {
                    Point point = validMoves[random.Next(validMoves.Count)];
                    position[0] = point.Y;
                    position[1] = point.X;
                }
                Console.WriteLine($"{Name} placed a disk at position: ({position[0]}, {position[1]})");
                gameBoard = MakeMove(position[0], position[1], gameBoard, validMoves);
                return gameBoard;
            });
        }

        public override Disk[,] MakeMove(int y, int x, Disk[,] gameBoard, List<Point> validMoves)
        {
            numOfChanges = 0;

            gameBoard[y, x] = Disk;
            numOfDisks++;
            foreach (Point pointItem in validMoves)
            {
                if (pointItem.X == x && pointItem.Y == y)
                {
                    for (int i = 0; i <= pointItem.FlipPoints.Count - 2 || i == 0; i += 2)
                    {
                        gameBoard[pointItem.FlipPoints[i], pointItem.FlipPoints[i + 1]] = Disk;

                        numOfChanges++;
                    }
                }
            }
            numOfDisks += numOfChanges;
            return gameBoard;
        }
    }
}
