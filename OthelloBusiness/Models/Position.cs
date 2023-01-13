namespace OthelloBusiness.Models
{
    /// <summary>
    /// Position klassen används för att hålla reda på vilka brickor som ska flippas för varje giltigt drag i validMoves listan.
    /// </summary>
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
