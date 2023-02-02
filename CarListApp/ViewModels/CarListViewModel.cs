using CarListApp.Services;
using System.Collections.ObjectModel;
using CarListApp.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels
{
    public partial class CarListViewModel : ViewModelBase
    {
        private const string CarListTitle = "Car list";

        [ObservableProperty]
        private bool _isRefreshing;

        public CarListViewModel()
        {
            Title = CarListTitle;
        }

        public ObservableCollection<Car> Cars { get; private set; } = new();

        [RelayCommand]
        public async Task GetCarsAsync()
        {
            if (IsLoading)
            {
                return;
            }

            try
            {
                IsLoading = true;
                var cars = await App.CarService.GetCarsAsync();

                foreach (var car in cars)
                {
                    Cars.Add(car);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await Shell.Current.DisplayAlert("Error", $"Failed to retrieve the list of cars: {ex.Message}.", "Close");
                throw;
            }
            finally
            {
                IsLoading = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public async Task OpenCarDetailsAsync(Car car)
        {
            if (car == null)
            {
                await Shell.Current.DisplayAlert("Error", "No car specified.", "Close");
            }

            await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>()
            {
                {
                    nameof(Car), car
                }
            });
        }
    }
}
