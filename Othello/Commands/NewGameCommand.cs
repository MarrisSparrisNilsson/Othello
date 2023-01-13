using OthelloPresentation.Views;

namespace OthelloPresentation.Commands
{
    /// <summary>
    /// NewGameCommand är kommandot som startar upp ett nytt spel.
    /// </summary>
    public class NewGameCommand : CommandBase
    {
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Initierar en ny instans av SetupGameDialog (startar ett nytt spel)
        /// </summary>
        public override void Execute(object? parameter)
        {
            SetupGameDialog setupGameDialog = new SetupGameDialog();
            setupGameDialog.ShowDialog();
        }
    }
}