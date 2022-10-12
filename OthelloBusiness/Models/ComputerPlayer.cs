
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

        public override int RequestMove(ref Disk[,] gameBoard, List<Point> validMoves)
        {
            if (validMoves.Count == 0)
            {
                return 0;
            }
            else
            {
                Point point = validMoves[random.Next(validMoves.Count)];
                int[] position = new int[2];
                position[0] = point.Y;
                position[1] = point.X;
                Console.WriteLine($"{Name} placed a disk at position: ({position[0]}, {position[1]})");
                return MakeMove(position[0], position[1], ref gameBoard, validMoves);
            }

        }
        public override int MakeMove(int y, int x, ref Disk[,] gameBoard, List<Point> validMoves)
        {
            int numOfChanges = 0;

            foreach (Point pointItem in validMoves)
            {
                if (pointItem.X == x && pointItem.Y == y)
                {
                    for (int i = 0; i < pointItem.FlipPoints.Count - 2 || i == 0; i += 2)
                    {
                        gameBoard[pointItem.FlipPoints[i], pointItem.FlipPoints[i + 1]] = Disk;
                        gameBoard[y, x] = Disk;
                        numOfChanges++;
                    }
                }
            }
            return numOfChanges;
        }
    }
}
