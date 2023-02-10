using CarListApp.Services;

namespace CarListApp.ViewModels;

public partial class LoadingViewModel : ViewModelBase
{
    private readonly UserInfoManager _userInfoManager;

    public LoadingViewModel(UserInfoManager userInfoManager)
    {
        _userInfoManager = userInfoManager;
        CheckUserLoginDetails();
    }

    private async void CheckUserLoginDetails()
    {
        var token = await _userInfoManager.GetAccessTokenAsync();

        if (token == null)
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
            return;
        }

        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}