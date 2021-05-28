using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Pages
{
    public class Index : PageModel
    {
        [BindProperty(SupportsGet = true)]
        [DisplayFormat(NullDisplayText="", ApplyFormatInEditMode=true)]
        public string SearchString { get; set; }
        public IList<Movie> listMovies { get; set;  }

        public Index( )
        {
            listMovies = new List<Movie>();
            this.SearchString = SearchString; 
                Movie movie = new Movie();
            movie.movieId = 12;
            movie.movieTitle = "fsdsdf";
            movie.movieYear = 2000; 
        }
        
        public async Task OnGetAsync(string SearchString)
        {
            //SearchString = this.SearchString;
            System.Diagnostics.Debug.WriteLine("---------------------------------------------------------------fsdfsdfsdfsdfsd");
            MoviesService moviesService = new MoviesService();
            listMovies = new List<Movie>();
            Movie[] moviesTemp = moviesService.GetAllMovies();
            
            if(String.IsNullOrEmpty(SearchString))
            {
                listMovies = moviesTemp.ToList(); 
            }
            
            var movies = from m in moviesTemp select m;

            movies = movies.Where(s => s.movieTitle.Contains(SearchString));
            
            listMovies = movies.ToList(); 

        }
    
        public async Task OnPostTask(string SearchString)
        {
            Console.WriteLine("---------------------------------------------------------------fsdfsdfsdfsdfsd");
            MoviesService moviesService = new MoviesService();
            listMovies = new List<Movie>();
            Movie[] moviesTemp = moviesService.GetAllMovies();

            var movies = from m in moviesTemp select m;

            movies = movies.Where(s => s.movieTitle.Contains("Dama"));
            
            listMovies = movies.ToList(); 
        }
      
    }
}