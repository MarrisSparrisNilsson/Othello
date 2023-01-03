﻿using OthelloBusiness.Controller;
using OthelloBusiness.Models;
using OthelloPresentation.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static GameManager? _GameManager { get; set; }

        private ICommand? _newGameCommand;
        public ICommand NewGameCmd =>
        _newGameCommand ??= new NewGameCommand();

        private ICommand? _gameExitCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICommand GameExitCmd =>
        _gameExitCommand ??= new GameExitCommand();

        private string whiteName;
        private string blackName;

        public string WhiteName
        {
            get { return whiteName; }
            set
            {
                whiteName = value;
                OnPropertyChanged();
            }
        }
        public string BlackName
        {
            get { return blackName; }
            set
            {
                blackName = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        //public GameWindowViewModel ViewModel { get; private set; } = new GameWindowViewModel();

        /*
        * Ha denna bara i GameGrid?
        * MainWindow updaterar inte längre spelbrädet.
        */

        /*
        * MainWindow ska innehålla:
        1. GameGrid instans
        2. New Game -> SetupGameDialog
        3. Exit Game -> Environment.Exit(0);
        4. Presenterar game status         
         */

        public MainWindow()
        {
            InitializeComponent();
        }

        public void StartGame(Player player1, Player player2)
        {
            WhiteName = player1.Name;
            BlackName = player2.Name;
            GameGrid grid = new GameGrid();
            MainWindow._GameManager = new GameManager(player1, player2, grid.UpdateGameBoard);
            MainWindow._GameManager.Play();
        }


        //while (true)
        //{
        //    App.Current.Dispatcher.Invoke(() =>
        //    {
        //        // Skriv kod som manipulerar gr¨anssnittobjekt h¨ar.
        //        Thread.Sleep(50);
        //        UpdateGameBoard();
        //        Thread.Sleep(50);
        //        foreach (Position pos in _GameManager.validMoves)
        //        {
        //            GameGrid.Board[(int)pos.Y][(int)pos.X] = Brushes.LightGray;
        //        }
        //    });

        //    //Tanken var att skapa gråa rutor för varje valid move

        //    if (_GameManager.skippedRounds == 2)
        //    {
        //        if (_GameManager.player1.numOfDisks == _GameManager.player2.numOfDisks)
        //        {
        //            DrawnDialog drawnDialog = new DrawnDialog();
        //            drawnDialog.ShowDialog();
        //        }
        //        else
        //        {
        //            WinnerDialog winnerDialog = new WinnerDialog();
        //            winnerDialog.WinnerMessage = ((_GameManager.player1.numOfDisks > _GameManager.player2.numOfDisks) ? _GameManager.player1.Name : _GameManager.player2.Name) + "wins!";
        //            winnerDialog.ShowDialog();
        //        }
        //    }
        //}


    }
}
