using System;

namespace OthelloPresentation.Commands
{
    /// <summary>
    /// GameExitCommand är kommandot som gör det möjligt att avsluta applikationen via ett grafiskt gränssnitt.
    /// </summary>
    public class GameExitCommand : CommandBase
    {
        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        /// <summary>
        /// Avslutar applikationen
        /// </summary>
        public override void Execute(object? parameter)
        {
            Environment.Exit(0);
        }
    }
}