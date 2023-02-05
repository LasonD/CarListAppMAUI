﻿namespace CarListApp.ViewModels;

public partial class LoadingPageViewModel : ViewModelBase
{
    private const string TokenKey = "token";

    public LoadingPageViewModel()
    {
        CheckUserLoginDetails();
    }

    private async void CheckUserLoginDetails()
    {
        var token = await SecureStorage.GetAsync(TokenKey);

        if (string.IsNullOrWhiteSpace(token))
        {
            await Shell.Current.GoToAsync(nameof(LoginPage));
            return;
        }

        // todo: check token

        await Shell.Current.GoToAsync(nameof(MainPage));
    }
}