namespace OthelloConsole.Models
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

        public override Point RequestMove(Disk[,] gameBoard, List<Point> validMoves)
        {
            Point? point = null;

            Thread.Sleep(2000);

            foreach (Point move in validMoves)
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
