namespace OthelloConsole.Models
{
    public class HumanPlayer : Player
    {

        public HumanPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
        }

        public override Position RequestMove(Disk[,] gameBoard, List<Position> validMoves)
        {
            Position? point = null;
            foreach (Position p in validMoves)
            {
                Console.WriteLine($"({p.Y},{p.X})");
            }
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
                    foreach (Position p in validMoves)
                    {
                        if (p.Y == position[0] && p.X == position[1])
                        {
                            isValidInput = true;
                            point = p;
                        }
                    }
                }
                if (!isValidInput) Console.WriteLine("Invalid move, please try again!");
            }

            return point;
        }
    }
}
