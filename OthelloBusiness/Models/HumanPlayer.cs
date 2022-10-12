namespace OthelloBusiness.Models
{
    public class HumanPlayer : Player
    {

        public HumanPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
        }

        public override int RequestMove(ref Disk[,] gameBoard, List<Point> validMoves)
        {

            if (validMoves.Count == 0)
            {
                return 0;
            }
            else
            {
                foreach (Point point in validMoves)
                {
                    Console.WriteLine($"({point.Y},{point.X})");
                }
                Console.Write("Please make a move: ");
                string? move = Console.ReadLine();
                string?[] moves = move.Split(",");
                int[] position = new int[moves.Length];
                position[0] = int.Parse(moves[0]);
                position[1] = int.Parse(moves[1]);
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
