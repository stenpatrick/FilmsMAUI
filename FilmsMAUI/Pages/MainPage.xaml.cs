using FilmsMAUI.Controller;

namespace FilmsMAUI.Pages;

public partial class MainPage : ContentPage
{
	private readonly TmdbServices _tmdbServices;
	int count = 0;

	public MainPage(TmdbServices tmdbServices)
	{
		InitializeComponent();
		_tmdbServices = tmdbServices;
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();
		var trending = await _tmdbServices.GetTrendingAsync();
    }
}