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
        public GameManager? gameManager { get; private set; }

        public enum PlayerType { HumanPlayer, ComputerPlayer }

        public ObservableCollection<PlayerType>? PlayerTypes { get; private set; } = new();
        //private Player? player1 = new HumanPlayer("", Disk.BLACK);
        private Player? player1;
        private Player? player2;
        //private Player? player2 = new ComputerPlayer("", Disk.BLACK);
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
                player1 = new HumanPlayer(tbName1.Text, Disk.BLACK);
            }
            else player1 = new ComputerPlayer(tbName1.Text, Disk.BLACK);
            if (cbPlayerType2.SelectedIndex == 0)
            {
                player2 = new HumanPlayer(tbName2.Text, Disk.WHITE);
            }
            else player2 = new ComputerPlayer(tbName2.Text, Disk.WHITE);

            gameManager = new GameManager(player1, player2);
            //gameManager.Play();
        }
    }
}
