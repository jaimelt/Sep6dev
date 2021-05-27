using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        public int SearchString { get; set; }
        public IList<Movie> listMovies { get; set;  }
       

        public async Task OnGetAsync(int SearchString)
        {
            MoviesService moviesService = new MoviesService();
            listMovies = new List<Movie>();
            Movie[] moviesTemp = moviesService.GetAllMovies();

            var movies = from m in moviesTemp select m;

            movies = movies.Where(s => s.movieYear == SearchString);


            listMovies = movies.ToList(); 

        }
    
        public async Task OnPostTask()
        {
            
        }
      
    }
}