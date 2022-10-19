using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace WpfMVVM.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private int carId = 0;
        public IList<Car> Cars { get; } = new ObservableCollection<Car>();

        public MainWindowViewModel()
        {
            Cars.Add(new Car { CarId = ++carId, Color = "Blue", Make = "Chevy", PetName = "Kit" });
            Cars.Add(new Car { CarId = ++carId, Color = "Red", Make = "Ford", PetName = "Rider" });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ICommand? changeColorCommand;
        public ICommand ChangeColorCommand => changeColorCommand ??= new RelayCommand<Car>((car) =>
        {
            if (car != null)
                car.Color = "Pink";
        });

        private ICommand? addCarCommand;
        public ICommand AddCarCommand => addCarCommand ??= new RelayCommand(() =>
        {
            Cars.Add(new Car() { CarId = ++carId, Color = "Yellow", Make = "VW", PetName = "Birdie" });
        });

        private ICommand? deleteCarCommand;
        public ICommand DeleteCarCommand => deleteCarCommand ??= new RelayCommand<Car>((car) =>
        {
            if (car != null) Cars.Remove(car);
        });

        private Car? selectedCar;
        public Car? SelectedCar
        {
            get => selectedCar;
            set
            {
                if (value == selectedCar) return;
                selectedCar = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }

        private string? selectedCarPetName;
        public string? SelectedCarPetName
        {
            get => selectedCarPetName;
            set
            {
                if (value == selectedCarPetName) return;
                selectedCarPetName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Info));
            }
        }

        public string? Info => $"{SelectedCar?.CarId} {SelectedCarPetName}";
    }
}



//using CommunityToolkit.Mvvm.ComponentModel;

//namespace OthelloPresentation.ViewModels
//{
//    [INotifyPropertyChanged]
//    public partial class GameWindowViewModel //: ObservableObject
//    {

//    }
//}