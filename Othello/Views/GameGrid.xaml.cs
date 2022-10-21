using OthelloBusiness.Models;
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
            Board[3][3] = Brushes.White;
            Board[3][4] = Brushes.Black;
            Board[4][3] = Brushes.Black;
            Board[4][4] = Brushes.White;
            //UpdateGameBoard();
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

                foreach (Position pos in MainWindow._GameManager.validMoves)
                {
                    if (pos.Y == y && pos.X == x)
                    {
                        //Player as HumanPlayer player;
                        (MainWindow._GameManager.player as HumanPlayer).X = (int)x;
                        (MainWindow._GameManager.player as HumanPlayer).Y = (int)y;

                        //{
                        //Board[(int)y][(int)x] = Brushes.White;
                        UpdateGameBoard();
                    }
                }


            }
        }
        private void UpdateGameBoard()
        {
            for (int y = 0; y < MainWindow._GameManager.gameBoard.GetLength(0); y++)
            {
                for (int x = 0; x < MainWindow._GameManager.gameBoard.GetLength(1); x++)
                {
                    if (Disk.WHITE == MainWindow._GameManager.gameBoard[y, x])
                    {
                        GameGrid.Board[y][x] = Brushes.White;

                    }
                    else if (Disk.BLACK == MainWindow._GameManager.gameBoard[y, x])
                    {
                        GameGrid.Board[y][x] = Brushes.Black;
                    }
                    else GameGrid.Board[y][x] = Brushes.Green;
                }
            }
        }
    }
}
