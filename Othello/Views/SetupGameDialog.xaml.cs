﻿using OthelloBusiness.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaktionslogik för SetupGameDialog.xaml
    /// </summary>
    public partial class SetupGameDialog : Window
    {
        public enum PlayerType { HumanPlayer, ComputerPlayer }

        public ObservableCollection<PlayerType>? PlayerTypes { get; private set; } = new();
        private Player? blackPlayer;
        private Player? whitePlayer;

        public SetupGameDialog()
        {
            InitializeComponent();
            PlayerTypes.Add(PlayerType.HumanPlayer);
            PlayerTypes.Add(PlayerType.ComputerPlayer);
            cbPlayerType1.SelectedIndex = 0;
            cbPlayerType2.SelectedIndex = 0;
        }

        /// <summary>
        /// Detta är en metod som lyssnar efter när användaren klickar på start knappen inuti SetupGameDialog
        /// och vidarebefodrar konfigurationen från textrutorna och komboboxen till GameWindows StartGame metod.
        /// </summary>
        private void btnDialogStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbPlayerType1.SelectedIndex == 0)
            {
                blackPlayer = new HumanPlayer(tbName1.Text, Disk.BLACK);
            }
            else blackPlayer = new ComputerPlayer(tbName1.Text, Disk.BLACK);
            if (cbPlayerType2.SelectedIndex == 0)
            {
                whitePlayer = new HumanPlayer(tbName2.Text, Disk.WHITE);
            }
            else whitePlayer = new ComputerPlayer(tbName2.Text, Disk.WHITE);

            ((GameWindow)App.Current.MainWindow).StartGame(blackPlayer, whitePlayer);
        }
    }
}
