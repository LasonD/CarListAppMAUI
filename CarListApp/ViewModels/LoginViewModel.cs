using CarListApp.Services;
using CarListApp.Services.Api;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly AuthApiService _authService;
    private readonly UserInfoManager _tokenManager;

    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;

    public LoginViewModel(AuthApiService authService, UserInfoManager tokenManager)
    {
        _authService = authService;
        _tokenManager = tokenManager;
    }

    [RelayCommand]
    public async Task LoginAsync()
    {
        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            await DisplayLoginErrorAsync();
            Password = null;
            return;
        }

        try
        {
            var token = await _authService.LoginAsync(Username, Password);
            await _tokenManager.SetAuthDataAsync(token);

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayLoginErrorAsync(ex.Message);
            Password = null;
        }
    }

    private async Task DisplayLoginErrorAsync(string message = null)
    {
        message = string.IsNullOrWhiteSpace(message) ? "Invalid username or password! Try again." : $"Something went wrong: {message}";

        await Shell.Current.DisplayAlert("Error", message, "Close");
    }
}