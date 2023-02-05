using System.Collections.ObjectModel;
using CarListApp.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Text;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CarListApp.Services;

namespace CarListApp.ViewModels;

public partial class CarListViewModel : ViewModelBase
{
    private readonly CarApiService _carApiService;
    private const string CarListTitle = "Car list";
    private const string AddCarText = "Add Car";
    private const string UpdateCarText = "Update Car";

    [ObservableProperty] private bool _isRefreshing;

    [ObservableProperty] private string _brand;

    [ObservableProperty] private string _model;

    [ObservableProperty] private string _vin;

    [ObservableProperty] private int? _editedCarId;

    [ObservableProperty] private string _addUpdateCarBtnText;

    public CarListViewModel(CarApiService carApiService)
    {
        _carApiService = carApiService;
        Title = CarListTitle;
        AddUpdateCarBtnText = AddCarText;
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
            Cars.Clear();
            IsLoading = true;

            IEnumerable<Car> cars;

            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                cars = await _carApiService.GetCarsAsync();
            }
            else
            {
                cars = App.CarService.GetCars();
            }

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
    public async Task AddUpdateCarAsync()
    {
        if (!IsValidCar(out var message))
        {
            await Shell.Current.DisplayAlert("Error", $"Cannot create or update a car: {message}", "Ok");
            return;
        }

        var car = new Car()
        {
            Brand = Brand,
            Model = Model,
            Vin = Vin,
        };

        try
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                if (EditedCarId != null)
                {
                    var updatedCount = await _carApiService.UpdateCarAsync(EditedCarId.Value, car);
                }
                else
                {
                    var insertedCount = await _carApiService.AddCarAsync(car);
                }
            }
            else
            {
                if (EditedCarId != null)
                {
                    var updatedCount = App.CarService.UpdateCar(EditedCarId.Value, car);
                }
                else
                {
                    var insertedCount = App.CarService.AddCar(car);
                }
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Error", $"Something went wrong while adding a car: {e.Message}", "Ok");
        }

        await GetCarsAsync();
    }

    [RelayCommand]
    public async Task EditCarAsync(int id)
    {
        if (id == EditedCarId)
        {
            Brand = null;
            Model = null;
            Vin = null;
            EditedCarId = null;
            AddUpdateCarBtnText = AddCarText;
            return;
        }

        AddUpdateCarBtnText = UpdateCarText;
        EditedCarId = id;

        var car = Cars.FirstOrDefault(c => c.Id == id);

        if (car == null)
        {
            await Shell.Current.DisplayAlert("Error", "Car not found. Try refreshing the list", "Ok");
            return;
        }

        Brand = car.Brand;
        Model = car.Model;
        Vin = car.Vin;
    }

    [RelayCommand]
    public async Task DeleteCarAsync(int id)
    {
        try
        {
            if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
            {
                var carsDeletedCount = App.CarService.DeleteCar(id);
            }
            else
            {
                var carsDeletedCount = await _carApiService.DeleteCarAsync(id);
            }
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Error", $"Something went wrong while deleting a car: {e.Message}", "Ok");
        }

        await GetCarsAsync();
    }

    [RelayCommand]
    public async Task OpenCarDetailsAsync(int id)
    {
        await Shell.Current.GoToAsync(nameof(CarDetailsPage), true, new Dictionary<string, object>()
        {
            {
                nameof(Car.Id), id
            }
        });
    }

    private bool IsValidCar(out string message)
    {
        var errorBuilder = new StringBuilder();

        if (string.IsNullOrWhiteSpace(Brand))
        {
            errorBuilder.Append("Car brand cannot be empty.");
        }

        if (string.IsNullOrWhiteSpace(Model))
        {
            errorBuilder.Append("Car model cannot be empty. ");
        }

        if (string.IsNullOrWhiteSpace(Vin))
        {
            errorBuilder.Append("Car VIN cannot be empty. ");
        }

        message = errorBuilder.ToString();
        return string.IsNullOrWhiteSpace(message);
    }
}