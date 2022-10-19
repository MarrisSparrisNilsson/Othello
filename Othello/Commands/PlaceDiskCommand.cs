using System.Drawing;
using System.Windows.Input;

namespace OthelloPresentation.Commands
{
    public class PlaceDiskCommand : CommandBase
    {
        //public delegate void PlaceDiskHandler(MouseButtonEventArgs? e);
        //private PlaceDiskHandler AddCar;

        private Point MouseX { get; set; }
        private Point MouseY { get; set; }

        public PlaceDiskCommand(MouseEventArgs e)
        {
            //MouseX = e.GetPosition(/*IInputElement*/).X;
        }



        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            parameter.
        }
    }
}