using System.Collections;
using System.Collections.Generic;
using aspnet_core_dotnet_core.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class GetAllMovies : PageModel
    {
        public IList<Movie> movies { get; set;  }
        
        public void OnGet()
        {
            MoviesService moviesService = new MoviesService();
            movies = new List<Movie>();
            Movie[] moviesTemp = moviesService.GetAllMovies();

            for (int i = 0; i < moviesTemp.Length; i++)
            {
                movies.Add(moviesTemp[i]);
            }
            
        }
    }
}