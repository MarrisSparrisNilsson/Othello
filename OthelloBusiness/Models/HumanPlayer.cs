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
            //return await Task.Run(() =>
            //{

            foreach (Point p in validMoves)
            {
                Console.WriteLine($"({p.Y},{p.X})");
            }
            Point? point = null;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine();
                Console.Write("Please make a move: ");
                string? move = Console.ReadLine();
                string?[] moves = move.Split(",");
                int[] position = new int[moves.Length];
                if (moves.Length > 1 && moves.Length < 3 && int.TryParse(moves[0], out position[0]) && int.TryParse(moves[1], out position[1])
                    && position[0] < 8 && position[0] >= 0 && position[1] >= 0 && position[1] < 8)
                {
                    foreach (Point p in validMoves)
                    {
                        if (p.Y == position[0] && p.X == position[1])
                        {
                            isValidInput = true;
                            point = p;
                        }
                    }
                }
                else Console.WriteLine("Invalid move, please try again!");
                //position[0] = int.Parse(moves[0]);
                //position[1] = int.Parse(moves[1]);

            }
            return MakeMove(point, gameBoard);
            //});
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
