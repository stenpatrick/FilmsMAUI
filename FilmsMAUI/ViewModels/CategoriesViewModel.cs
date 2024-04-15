using CommunityToolkit.Mvvm.ComponentModel;
using FilmsMAUI.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmsMAUI.ViewModels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        private IEnumerable<Genre> _genreList;

        public CategoriesViewModel(TmdbService tmdbService) 
        {
            Categories = new ObservableCollection<string>(
                new string[]
                {"My List", "Downloads"});
            _tmdbService = tmdbService;
        }
        public ObservableCollection<string> Categories { get; set; }
        
        public async Task InitializeAsync()
        {
            _genreList ??= await _tmdbService.GetGenresAsync();
            Categories.Clear();
            Categories.Add("My List");
            Categories.Add("Downloads");


            foreach (var genre in await _tmdbService.GetGenresAsync()) 
            {
                Categories.Add(genre.Name);
            }
        }
    }
}
