using OthelloBusiness.Models;
using System;
using System.Collections.Generic;
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
        //INotifyCollectionChanged

        public static int positionX { get; set; }
        public static int positionY { get; set; }
        public static ObservableCollection<ObservableCollection<Brush>>? Board { get; set; }

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
            InitializeComponent();
        }

        //public event NotifyCollectionChangedEventHandler? CollectionChanged;

        //protected void OnCollectionChanged([CallerMemberName] string name = null)
        //{
        //    CollectionChanged?.Invoke(this, new CollectionChangeEventArgs(name));
        //}

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(gGameBoard);
            if (p.X > 60 && p.Y > 60 && p.X < 540)
            {
                int y = (int)Math.Floor(Math.Ceiling((double)p.Y) / 60);
                int x = (int)Math.Floor(Math.Ceiling((double)p.X) / 60);

                if (x >= 1) x -= 1;
                if (y >= 1) y -= 1;

                if (Board[y][x] == Brushes.Gray)
                {
                    GameWindow._GameManager.SetMove(x, y);
                }
            }
        }

        public void UpdateGameBoard(Disk[,] gameBoardCopy, List<Position> validMoves)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                for (int y = 0; y < gameBoardCopy.GetLength(0); y++)
                {
                    for (int x = 0; x < gameBoardCopy.GetLength(1); x++)
                    {
                        if (Disk.WHITE == gameBoardCopy[y, x])
                        {
                            Board[y][x] = Brushes.White;
                        }
                        else if (Disk.BLACK == gameBoardCopy[y, x])
                        {
                            Board[y][x] = Brushes.Black;
                        }
                        else Board[y][x] = Brushes.Green;
                    }
                }
                foreach (Position pos in validMoves)
                {
                    Board[pos.Y][pos.X] = Brushes.Gray;
                }
            });
        }
    }
}
