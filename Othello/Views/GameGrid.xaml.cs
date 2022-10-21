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
        //public int positionX { get; set; }
        //public int positionY { get; set; }
        public ObservableCollection<ObservableCollection<Brush>> Board { get; private set; }

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
            // Vi måste typ ha en if sats eller liknande som först kollar att den point som tryckts på matchar en punkt i valid moves.
            if (p.X > 60 && p.Y > 60)
            {

                double y = Math.Floor(Math.Ceiling((double)p.Y) / 60);
                double x = Math.Floor(Math.Ceiling((double)p.X) / 60);

                if (x >= 1) x -= 1;
                if (y >= 1) y -= 1;
                //foreach (var item in collection)
                //{
                //positionX = (int)x;
                //positionY = (int)y;
                //if(gameManager.validMoves)
                //}
                //gameMananager.gameboard
                Board[(int)y][(int)x] = Brushes.White;
            }
        }
    }
}
