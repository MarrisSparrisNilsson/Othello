using OthelloPresentation.Views;

namespace OthelloPresentation.Commands
{
    public class NewGameCommand : CommandBase
    {

        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            //Start setupGameDialog
            SetupGameDialog setupGameDialog = new SetupGameDialog();
            setupGameDialog.ShowDialog();
        }
    }
}