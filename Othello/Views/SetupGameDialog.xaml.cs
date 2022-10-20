using OthelloBusiness.Controller;
using OthelloBusiness.Models;
using System.Collections.ObjectModel;
using System.Windows;

namespace OthelloPresentation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SetupGameDialog : Window
    {
        public enum PlayerType { HumanPlayer, ComputerPlayer }
        public ObservableCollection<PlayerType>? PlayerTypes { get; private set; } = new();
        private Player? player1 = null;
        private Player? player2 = null;
        public SetupGameDialog()
        {
            InitializeComponent();
            PlayerTypes.Add(PlayerType.HumanPlayer);
            PlayerTypes.Add(PlayerType.ComputerPlayer);
            cbPlayerType1.SelectedIndex = 0;
            cbPlayerType2.SelectedIndex = 0;
        }

        private void btnDialogStart_Click(object sender, RoutedEventArgs e)
        {
            if (cbPlayerType1.SelectedIndex == 0)
            {
                player1 = new HumanPlayer(player1.Name = tbName1.Text, player1.Disk = Disk.BLACK);
            }
            else player1 = new ComputerPlayer(player1.Name = tbName1.Text, player1.Disk = Disk.BLACK);
            if (cbPlayerType2.SelectedIndex == 0)
            {
                player2 = new HumanPlayer(player2.Name = tbName2.Text, player2.Disk = Disk.WHITE);
            }
            else player2 = new ComputerPlayer(player2.Name = tbName2.Text, player2.Disk = Disk.WHITE);

            GameManager gameManager = new GameManager(player1, player2);
        }
    }
}
