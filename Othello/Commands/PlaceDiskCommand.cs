using System.Windows.Input;
using System.Windows.Media;

namespace OthelloPresentation.Commands
{
    public class PlaceDiskCommand : CommandBase
    {
        //public delegate void PlaceDiskHandler(MouseButtonEventArgs? e);
        //private PlaceDiskHandler AddCar;

        //private Point MouseX { get; set; }
        //private Point MouseY { get; set; }

        private SolidColorBrush brushWhite = Brushes.White;
        private SolidColorBrush brushBlack = Brushes.Black;

        //public PlaceDiskCommand(MouseEventArgs e)
        //{
        //    //MouseX = e.GetPosition(/*IInputElement*/).X;
        //}



        //public override bool CanExecute(object? parameter)
        //{
        //    return true;
        //}

        //public override void Execute(object? parameter)
        //{
        //    parameter.
        //}


        public override bool CanExecute(object? parameter)
        {
            return (parameter as MouseButtonEventArgs) != null;
        }
        public override void Execute(object? parameter)
        {
            if (parameter is MouseButtonEventArgs e)
            {
                //Point p = e.GetPosition(bGameBoard);
                ////Ellipse ellipse = new Ellipse();
                ////ellipse.Height = 10;
                ////ellipse.Width = 10;
                //ellipse.Fill = brushWhite;
                //ellipse.Fill = brushBlack;

                //Canvas.SetLeft(ellipse, p.X);
                //Canvas.SetTop(ellipse, p.Y);
                //bGameBoard.Children.Add(ellipse);
            }
        }
    }
}