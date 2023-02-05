using CarListApp.ViewModels;

namespace CarListApp;

public partial class LoadingPage : ContentPage
{
	public LoadingPage(LoadingViewModel loadingViewModel)
	{
		InitializeComponent();
		BindingContext = loadingViewModel;
	}
}