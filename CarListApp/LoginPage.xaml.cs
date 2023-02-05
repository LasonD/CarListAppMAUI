using CarListApp.ViewModels;

namespace CarListApp;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginPageViewModel loginPageViewModel)
	{
		InitializeComponent();
        BindingContext = loginPageViewModel;
    }
}