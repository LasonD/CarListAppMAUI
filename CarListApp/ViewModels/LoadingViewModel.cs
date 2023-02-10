using CarListApp.Services.Api;

namespace CarListApp.ViewModels;

public partial class LoadingViewModel : ViewModelBase
{
    private readonly PersistedTokenManager _persistedTokenManager;

    public LoadingViewModel(PersistedTokenManager persistedTokenManager)
    {
        _persistedTokenManager = persistedTokenManager;
        CheckUserLoginDetails();
    }

    private async void CheckUserLoginDetails()
    {
        var token = await _persistedTokenManager.GetTokenAsync();

        if (token == null)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
            return;
        }

        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}