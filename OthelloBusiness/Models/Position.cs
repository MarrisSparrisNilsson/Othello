namespace OthelloBusiness.Models
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
    }
}
