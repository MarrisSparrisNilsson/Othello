
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
