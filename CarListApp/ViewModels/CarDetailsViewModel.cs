using CarListApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Car), nameof(Car))]
    public partial class CarDetailsViewModel : ViewModelBase
    {
        [ObservableProperty]
        private Car _car;

        public CarDetailsViewModel()
        {
            // Title = $"{Car.Brand} {Car.Model}";
        }
    }
}
