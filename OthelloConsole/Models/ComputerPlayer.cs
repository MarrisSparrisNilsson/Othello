namespace OthelloConsole.Models
{
    public class ComputerPlayer : Player
    {
        private Random? random;
        public ComputerPlayer(string name, Disk disk)
        {
            Name = name;
            Disk = disk;
            random = new Random();
        }

        public override Position RequestMove(Disk[,] gameBoard, List<Position> validMoves)
        {
            Position? point = null;

            Thread.Sleep(2000);

            foreach (Position move in validMoves)
            {
                if (move.Y == 0 && move.X == 0 || move.Y == 0 && move.X == 7 || move.Y == 7 && move.X == 0 || move.Y == 7 && move.X == 7)
                {
                    point = move;
                    break;
                }
            }
            if (point == null) point = validMoves[random.Next(validMoves.Count)];

            Console.WriteLine($"{Name} placed a disk at position: ({point.Y}, {point.X})");
            return point;
        }
    }
}
