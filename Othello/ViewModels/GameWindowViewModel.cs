using OthelloPresentation.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace OthelloPresentation.ViewModels
{
    public class GameWindowViewModel : INotifyPropertyChanged
    {

        //public ObservableCollection<ObservableCollection<Brush>> Board { get; private set; } = new();
        private ICommand? _placeDiskCommand;
        public ICommand PlaceDiskCmd =>
        _placeDiskCommand ??= new PlaceDiskCommand();

        private ICommand? _gameExitCommand;
        public ICommand GameExitCmd =>
        _gameExitCommand ??= new GameExitCommand();

        public event PropertyChangedEventHandler? PropertyChanged;

        public GameWindowViewModel()
        {
            //for (int row = 0; row < 8; ++row)
            //{
            //    Board.Add(new ObservableCollection<Brush>());
            //    for (int col = 0; col < 8; ++col)
            //    {
            //        Board[row].Add(Brushes.Green);
            //    }
            //}
        }

        //// På något sätt behöver vi också när validMoves returnerar uppdatera guit och färglägga alla punkter i guit i grått.
        //private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    Point p = e.GetPosition(gGameBoard);
        //    // Vi måste typ ha en if sats eller liknande som först kollar att den point som tryckts på matchar en punkt i valid moves.
        //    if (p.X > 60 && p.Y > 60)
        //    {

        //        double y = Math.Floor(Math.Ceiling((double)p.Y) / 60);
        //        double x = Math.Floor(Math.Ceiling((double)p.X) / 60);

        //        if (x >= 1) x -= 1;
        //        if (y >= 1) y -= 1;

        //        Board[(int)y][(int)x] = Brushes.White;
        //    }
        //}


        //    private int carId = 0;
        //    public IList<Car> Cars { get; } = new ObservableCollection<Car>();

        //    public MainWindowViewModel()
        //    {
        //        Cars.Add(new Car { CarId = ++carId, Color = "Blue", Make = "Chevy", PetName = "Kit" });
        //        Cars.Add(new Car { CarId = ++carId, Color = "Red", Make = "Ford", PetName = "Rider" });
        //    }

        //    public event PropertyChangedEventHandler? PropertyChanged;
        //    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //    {
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //    }

        //    private ICommand? changeColorCommand;
        //    public ICommand ChangeColorCommand => changeColorCommand ??= new RelayCommand<Car>((car) =>
        //    {
        //        if (car != null)
        //            car.Color = "Pink";
        //    });

        //    private ICommand? addCarCommand;
        //    public ICommand AddCarCommand => addCarCommand ??= new RelayCommand(() =>
        //    {
        //        Cars.Add(new Car() { CarId = ++carId, Color = "Yellow", Make = "VW", PetName = "Birdie" });
        //    });

        //    private ICommand? deleteCarCommand;
        //    public ICommand DeleteCarCommand => deleteCarCommand ??= new RelayCommand<Car>((car) =>
        //    {
        //        if (car != null) Cars.Remove(car);
        //    });

        //    private Car? selectedCar;
        //    public Car? SelectedCar
        //    {
        //        get => selectedCar;
        //        set
        //        {
        //            if (value == selectedCar) return;
        //            selectedCar = value;
        //            OnPropertyChanged();
        //            OnPropertyChanged(nameof(Info));
        //        }
        //    }

        //    private string? selectedCarPetName;
        //    public string? SelectedCarPetName
        //    {
        //        get => selectedCarPetName;
        //        set
        //        {
        //            if (value == selectedCarPetName) return;
        //            selectedCarPetName = value;
        //            OnPropertyChanged();
        //            OnPropertyChanged(nameof(Info));
        //        }
        //    }

        //    public string? Info => $"{SelectedCar?.CarId} {SelectedCarPetName}";
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