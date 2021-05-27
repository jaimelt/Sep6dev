using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet_core_dotnet_core.repo;

namespace aspnet_core_dotnet_core.Data
{
    public class MoviesService
    {
        MoviesRepo moviesRepo = new MoviesRepo();
        public Movie[] GetAllMovies()
        {
            ArrayList movies = moviesRepo.GetMovies();
            Movie[] moviesArr = new Movie[movies.Count];
            
          if (movies.Count!=0)
            {
                for (int i = 0; i < movies.Count; i++)
                {
                    moviesArr[i] = (Movie) movies[i];
                }
            }
            
            return moviesArr;
        }


        public IEnumerable<Movie> searchMovieByName(string movieName)
        {
            return moviesRepo.SearchMovieByName(movieName);
        }

         

  
    }
}
