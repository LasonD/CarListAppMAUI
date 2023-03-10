using CarListApp.Services;
using CarListApp.Services.Api;
using CarListApp.ViewModels;
using CarListApp.Views;

namespace CarListApp;

public static class MauiProgram
{
    private const string DbFileName = "cars.db3";

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        var dbPath = Path.Combine(FileSystem.AppDataDirectory, DbFileName);

        builder.Services.AddTransient(_ => new CarService(dbPath).Init());
        builder.Services.AddTransient<CarApiService>();
        builder.Services.AddTransient<AuthApiService>();
        builder.Services.AddSingleton<UserInfoManager>();

        builder.Services.AddTransient<CarListViewModel>();
        builder.Services.AddTransient<LoadingViewModel>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<CarDetailsViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<LoadingPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<CarDetailsPage>();

		return builder.Build();
	}
}
