namespace OthelloConsole.Models
{
    public class GameBoard
    {
        private Disk LastDisk = Disk.BLANK;
        private List<Point> validMoves;
        private Point? point = null;

        public GameBoard()
        {
            validMoves = new List<Point>();
        }

        public List<Point> ValidMoves(Player player, Disk[,] gameBoard)
        {
            validMoves.Clear();
            for (int y = 0; y < gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < gameBoard.GetLength(1); x++)
                {
                    if (player.Disk == gameBoard[y, x])
                    {
                        if (y > 0) // NORTH
                            ValidMove(y, x, player, Directions.NORTH, gameBoard);
                        if (y > 0 && x < 7) // NORTH EAST
                            ValidMove(y, x, player, Directions.NORTH_EAST, gameBoard);
                        if (x < 7) // EAST
                            ValidMove(y, x, player, Directions.EAST, gameBoard);
                        if (y < 7 && x < 7) // SOUTH EAST
                            ValidMove(y, x, player, Directions.SOUTH_EAST, gameBoard);
                        if (y < 7) // SOUTH
                            ValidMove(y, x, player, Directions.SOUTH, gameBoard);
                        if (y < 7 && x > 0) // SOUTH WEST
                            ValidMove(y, x, player, Directions.SOUTH_WEST, gameBoard);
                        if (x > 0) // WEST
                            ValidMove(y, x, player, Directions.WEST, gameBoard);
                        if (y > 0 && x > 0) // NORTH WEST
                            ValidMove(y, x, player, Directions.NORTH_WEST, gameBoard);
                    }
                }
            }
            return validMoves;
        }
        public void ValidMove(int y, int x, Player player, Directions directionType, Disk[,] gameBoard)
        {
            if (Directions.NORTH == directionType) // NORTH
                y--;
            else if (Directions.NORTH_EAST == directionType) // NORTH EAST
            { y--; x++; }
            else if (Directions.EAST == directionType) // EAST
                x++;
            else if (Directions.SOUTH_EAST == directionType) // SOUTH EAST
            { y++; x++; }
            else if (Directions.SOUTH == directionType) // SOUTH
                y++;
            else if (Directions.SOUTH_WEST == directionType) // SOUTH WEST
            { y++; x--; }
            else if (Directions.WEST == directionType) // WEST
                x--;
            else if (Directions.NORTH_WEST == directionType) // NORTH WEST
            { y--; x--; }

            if (gameBoard[y, x] == Disk.BLANK)
            {
                if (LastDisk != player.Disk && LastDisk != Disk.BLANK)
                {
                    point.X = x;
                    point.Y = y;
                    validMoves.Add(point);
                    point = null;
                }
                return;
            }
            else if (gameBoard[y, x] != player.Disk)
            {
                if (point == null)
                {
                    point = new Point();
                }
                LastDisk = gameBoard[y, x];
                point.FlipPoints.Add(y);
                point.FlipPoints.Add(x);
                //point.flipPoints[0] = y;
                //point.flipPoints[1] = x;
                if (Directions.NORTH == directionType && y > 0) // NORTH
                    ValidMove(y, x, player, Directions.NORTH, gameBoard);
                else if (Directions.NORTH_EAST == directionType && y > 0 && x < 7) // NORTH EAST
                    ValidMove(y, x, player, Directions.NORTH_EAST, gameBoard);
                else if (Directions.EAST == directionType && x < 7) // EAST
                    ValidMove(y, x, player, Directions.EAST, gameBoard);
                else if (Directions.SOUTH_EAST == directionType && y < 7 && x < 7) // SOUTH EAST
                    ValidMove(y, x, player, Directions.SOUTH_EAST, gameBoard);
                else if (Directions.SOUTH == directionType && y < 7) // SOUTH
                    ValidMove(y, x, player, Directions.SOUTH, gameBoard);
                else if (Directions.SOUTH_WEST == directionType && y < 7 && x > 0) // SOUTH WEST
                    ValidMove(y, x, player, Directions.SOUTH_WEST, gameBoard);
                else if (Directions.WEST == directionType && x > 0) // WEST
                    ValidMove(y, x, player, Directions.WEST, gameBoard);
                else if (Directions.NORTH_WEST == directionType && y > 0 && x > 0) // NORTH WEST
                    ValidMove(y, x, player, Directions.NORTH_WEST, gameBoard);
                LastDisk = Disk.BLANK;
                point = null;
            }
        }

        public Disk[,] MakeMove(Point point, Disk[,] gameBoard, Player player)
        {
            player.numOfChanges = 0;

            gameBoard[point.Y, point.X] = player.Disk;
            player.numOfDisks++;

            for (int i = 0; i <= point.FlipPoints.Count - 2 || i == 0; i += 2)
            {
                gameBoard[point.FlipPoints[i], point.FlipPoints[i + 1]] = player.Disk;
                player.numOfChanges++;

            }

            player.numOfDisks += player.numOfChanges;
            return gameBoard;
        }
    }
}
