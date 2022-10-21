using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for GameGrid.xaml
    /// </summary>
    public partial class GameGrid : UserControl
    {
        public static int positionX { get; set; }
        public static int positionY { get; set; }
        public static ObservableCollection<ObservableCollection<Brush>> Board { get; set; }

        /// <summary>
        /// This implementation is needed!
        /// </summary>

        public GameGrid()
        {
            Board = new ObservableCollection<ObservableCollection<Brush>>();
            for (int row = 0; row < 8; ++row)
            {
                Board.Add(new ObservableCollection<Brush>());
                for (int col = 0; col < 8; ++col)
                {
                    Board[row].Add(Brushes.Green);
                }
            }
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(gGameBoard);
            if (p.X > 60 && p.Y > 60)
            {

                double y = Math.Floor(Math.Ceiling((double)p.Y) / 60);
                double x = Math.Floor(Math.Ceiling((double)p.X) / 60);

                if (x >= 1) x -= 1;
                if (y >= 1) y -= 1;

                //foreach (Position point in MainWindow._GameManager.validMoves)
                //{
                //    if (point.Y == y && point.X == x)
                //    {
                //        MainWindow._GameManager.player.X = (int)x;
                //        MainWindow._GameManager.player.Y = (int)y;
                //    }
                //}


                //Board[(int)y][(int)x] = Brushes.White;
            }
        }
    }
}
