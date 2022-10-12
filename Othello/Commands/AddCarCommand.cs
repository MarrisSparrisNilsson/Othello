using System.Collections.ObjectModel;
using System.Linq;
using WpfMVVM.Models;

namespace OthelloPresentation.Commands
{
    public class AddCarCommand : CommandBase
    {
        public delegate void AddCarHandler();
        private AddCarHandler AddCar;

        public AddCarCommand(AddCarHandler addCarHandler)
        {
            AddCar = addCarHandler;
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            AddCar();
        }
    }
}