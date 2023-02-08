using CarListApp.Services.Api;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CarListApp.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly AuthApiService _authService;
    private readonly PersistedTokenManager _tokenManager;

    [ObservableProperty] private string _username;
    [ObservableProperty] private string _password;

    public LoginViewModel(AuthApiService authService, PersistedTokenManager tokenManager)
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
            await _tokenManager.SetTokenAsync(token);
        }
        catch
        {
            await DisplayLoginErrorAsync();
            ClearForm();
        }
    }

    private void ClearForm()
    {
        Username = null;
        Password = null;
    }

    private async Task DisplayLoginErrorAsync()
    {
        await Shell.Current.DisplayAlert("Error", "Invalid username or password! Try again.", "Close");
    }
}