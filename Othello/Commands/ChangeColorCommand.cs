using WpfMVVM.Models;

namespace OthelloPresentation.Commands
{
    public class ChangeColorCommand : CommandBase
    {
        public delegate void ChangeColorHandler(Car? car);
        private ChangeColorHandler ChangeColor;

        public ChangeColorCommand(ChangeColorHandler changeColorHandler)
        {
            ChangeColor = changeColorHandler;
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter is Car ? true : false;
        }

        public override void Execute(object? parameter)
        {
            Car? car = parameter as Car;
            ChangeColor(car);
        }
    }
}