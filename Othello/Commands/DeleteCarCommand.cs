using System.Windows.Controls;
using WpfMVVM.Models;

namespace OthelloPresentation.Commands
{
    public class DeleteCarCommand : CommandBase
    {
        public delegate void DeleteCarHandler(Car? car);
        private DeleteCarHandler DeleteCar;

        public DeleteCarCommand(DeleteCarHandler deleteCarHandler)
        {
            DeleteCar = deleteCarHandler;
        }

        public override bool CanExecute(object? parameter)
        {
            return parameter is Car ? true : false;
        }

        public override void Execute(object? parameter)
        {
            Car? car = parameter as Car;
            DeleteCar(car);
        }
    }
}