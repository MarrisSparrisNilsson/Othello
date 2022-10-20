namespace OthelloPresentation.Commands
{
    public class StartGameCommand : CommandBase
    {

        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            //Play();
        }
    }
}