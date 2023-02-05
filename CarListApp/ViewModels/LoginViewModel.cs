using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;

    [RelayCommand]
    public async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await DisplayLoginErrorAsync();
            return;
        }


    }

    private async Task DisplayLoginErrorAsync()
    {
        await Shell.Current.DisplayAlert("Error", "Invalid username or password! Try again.", "Close");
    }
}