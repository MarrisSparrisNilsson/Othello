using System;

namespace OthelloPresentation.Commands
{
    public class GameExitCommand : CommandBase
    {

        public override bool CanExecute(object? parameter)
        {
            return true;
        }
        public override void Execute(object? parameter)
        {
            Environment.Exit(0);
        }
    }
}