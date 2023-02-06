using CarListApp.Services.Api;

namespace CarListApp.ViewModels;

public partial class LoadingViewModel : ViewModelBase
{
    private readonly TokenManager _tokenManager;

    public LoadingViewModel(TokenManager tokenManager)
    {
        _tokenManager = tokenManager;
        CheckUserLoginDetails();
    }

    private async void CheckUserLoginDetails()
    {
        var token = await _tokenManager.GetTokenAsync();

        if (token == null || string.IsNullOrWhiteSpace(token))
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
            return;
        }

        // todo: check token

        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}