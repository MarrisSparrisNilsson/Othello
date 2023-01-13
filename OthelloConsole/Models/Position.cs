namespace OthelloConsole.Models
{
    public class Position
    {
        public List<int>? FlipPositions { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Position()
        {
            FlipPositions = new List<int>();
        }

        //public override string ToString() => $"{X.ToString()}{Y.ToString()}";
    }
}
