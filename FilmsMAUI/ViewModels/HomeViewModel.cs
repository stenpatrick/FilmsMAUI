using CommunityToolkit.Mvvm.ComponentModel;
using FilmsMAUI.Controller;
using FilmsMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsMAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbServices _tmdbService;
        public HomeViewModel(TmdbServices tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [ObservableProperty]
        private Media _trendingMovie;

        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovie { get; set; } = new();
        public async Task InitalizeAsync()
        {
            var trendingList = await _tmdbService.GetTrendingAsync();
            if (trendingList?.Any() == true)
            {
                foreach (var trending in trendingList) 
                { 
                    Trending.Add(trending);
                }
            }
            var netflixOriginals = await _tmdbService.GetNetflixOriginalAsync();
            if(netflixOriginals?.Any() == true)
            {
                foreach (var trending in trendingList)
                {
                    Trending.Add(trending);
                }

            }
        }
    }
}
