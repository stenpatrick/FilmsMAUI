using CommunityToolkit.Maui;
using FilmsMAUI.Controller;
using FilmsMAUI.Pages;
using Microsoft.Extensions.Logging;

namespace FilmsMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
				fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
			});
		builder.Services.AddHttpClient(Controller.TmdbServices.TmdbHttpClientName,
			HttpClient => HttpClient.BaseAddress = new Uri("https://api.themoviedb.org"));
		builder.Services.AddSingleton<TmdbServices>();
		builder.Services.AddSingleton<MainPage>();
		return builder.Build();

	}
}
