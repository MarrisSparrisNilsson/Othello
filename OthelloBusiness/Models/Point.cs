namespace OthelloBusiness.Models
{
    public class Point
    {
        public List<int> FlipPoints { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Point()
        {
            FlipPoints = new List<int>();
        }

        //public override string ToString() => $"{X.ToString()}{Y.ToString()}";
    }
}
