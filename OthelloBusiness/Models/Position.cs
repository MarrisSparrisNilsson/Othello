namespace OthelloBusiness.Models
{
    // <summary>
    /// Beskriv metoden h ̈ar
    /// </summary>
    /// <param name="paramname"> Beskriv parameter h ̈ar </param>
    /// <returns> Beskriv returv ̈ardet h ̈ar </returns>
    public class Position
    {
        public List<int>? FlipPositions { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        // <summary>
        /// Beskriv metoden h ̈ar
        /// </summary>
        /// <param name="paramname"> Beskriv parameter h ̈ar </param>
        /// <returns> Beskriv returv ̈ardet h ̈ar </returns>
        public Position()
        {
            FlipPositions = new List<int>();
        }
    }
}
