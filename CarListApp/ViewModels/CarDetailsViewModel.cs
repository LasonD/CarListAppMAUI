using CarListApp.Models;
using CarListApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public partial class CarDetailsViewModel : ViewModelBase, IQueryAttributable
    {
        private readonly CarApiService _carApiService;

        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private Car _car;

        public CarDetailsViewModel(CarApiService carApiService)
        {
            _carApiService = carApiService;
        }

        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            Id = Convert.ToInt32(query[nameof(Id)]);

            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                Car = await _carApiService.GetCarAsync(Id);
            }
            else
            {
                Car = App.CarService.GetById(Id);
            }
        }
    }
}
