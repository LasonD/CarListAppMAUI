using System.Collections.ObjectModel;
using CarListApp.Models;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;
using System.Text;
using CarListApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarListApp.ViewModels;

public partial class CarListViewModel : ViewModelBase
{
    private const string CarListTitle = "Car list";

    [ObservableProperty] private bool _isRefreshing;

    [ObservableProperty] private string _brand;

    [ObservableProperty] private string _model;

    [ObservableProperty] private string _vin;

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
            Cars.Clear();
            IsLoading = true;
            var cars = App.CarService.GetCars();

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
    public async Task AddCarAsync()
    {
        if (!IsValidCar(out var message))
        {
            await Shell.Current.DisplayAlert("Error", $"Cannot create a car: {message}", "Ok");
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
            App.CarService.AddCar(car);
        }
        catch (Exception e)
        {
            await Shell.Current.DisplayAlert("Error", $"Something went wrong while adding a car: {e.Message}", "Ok");
        }

        await GetCarsAsync();
    }

    [RelayCommand]
    public async Task DeleteCarAsync(int id)
    {
        try
        {
            var carsDeletedCount = App.CarService.DeleteCar(id);
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