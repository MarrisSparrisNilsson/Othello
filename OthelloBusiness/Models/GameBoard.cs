namespace OthelloBusiness.Models
{
    public class GameBoard
    {
        private Disk? LastDisk = Disk.BLANK;
        private List<Position>? validMoves;
        private Position? position = null;
        public Disk[,]? gameBoard = new Disk[8, 8];

        public GameBoard()
        {
            gameBoard[3, 3] = Disk.WHITE;
            gameBoard[3, 4] = Disk.BLACK;
            gameBoard[4, 3] = Disk.BLACK;
            gameBoard[4, 4] = Disk.WHITE;
            validMoves = new List<Position>();
        }

        public List<Position> ValidMoves(Player player, Disk[,] gameBoard)
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

            List<Position> filteredList = new List<Position>();

            foreach (Position p in validMoves)
            {
                bool noMatchingPoints = true;
                for (int i = 0; i < filteredList.Count; i++)
                {
                    if ((filteredList[i].X == p.X && filteredList[i].Y == p.Y))
                    {
                        for (int j = 0; j <= p.FlipPositions.Count - 2; j += 2)
                        {
                            filteredList[i].FlipPositions.Add(p.FlipPositions[j]);
                            filteredList[i].FlipPositions.Add(p.FlipPositions[j + 1]);
                        }
                        noMatchingPoints = false;
                    }
                }
                if (noMatchingPoints)
                    filteredList.Add(p);
            }

            return filteredList;
        }

        private void ValidMove(int y, int x, Player player, Directions directionType, Disk[,] gameBoard)
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
                    position.X = x;
                    position.Y = y;
                    validMoves.Add(position);
                    position = null;
                }
                return;
            }
            else if (gameBoard[y, x] != player.Disk)
            {
                if (position == null)
                {
                    position = new Position();
                }
                LastDisk = gameBoard[y, x];
                position.FlipPositions.Add(y);
                position.FlipPositions.Add(x);
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
                position = null;
            }
        }

        public Disk[,] MakeMove(Position pos, Disk[,] gameBoard, Player player)
        {
            player.numOfChanges = 0;

            gameBoard[pos.Y, pos.X] = player.Disk;
            player.numOfDisks++;

            for (int i = 0; i <= pos.FlipPositions.Count - 2; i += 2)
            {
                gameBoard[pos.FlipPositions[i], pos.FlipPositions[i + 1]] = player.Disk;
                player.numOfChanges++;

            }

            player.numOfDisks += player.numOfChanges;

            return gameBoard;
        }
    }
}
