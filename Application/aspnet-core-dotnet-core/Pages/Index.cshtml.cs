using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnet_core_dotnet_core.Data;

namespace aspnet_core_dotnet_core.Pages
{
    public class IndexModel : PageModel
    {

        public IndexModel ()
        {
            /* movies = MoviesService.GetAllMovies(); */
            Movie movie = new Movie();
            movies = new Movie[1];
            movies[0] = movie;
            
        }

        MoviesService MoviesService = new MoviesService();
        string searchTerm = "";
        public Movie[] movies;
        public void OnGet()
        {

        }
        public string DoTest()
        {
            return "Index";
        }
        
        public string Search()
        {
            movies = MoviesService.searchMovieByName(searchTerm);

            return "sss";
  
        }
        public void ViewMovie()
        {

        }
    }
}