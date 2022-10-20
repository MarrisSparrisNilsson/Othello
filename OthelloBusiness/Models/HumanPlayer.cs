namespace OthelloBusiness.Models
{
    public class HumanPlayer : Player
    {

        public HumanPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
        }

        public async override Task<Disk[,]> RequestMoveAsync(Disk[,] gameBoard, List<Point> validMoves)
        {
            return await Task.Run(() =>
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
                //return await MakeMove(position[0], position[1], gameBoard, validMoves);

                return MakeMove(position[0], position[1], gameBoard, validMoves);
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
