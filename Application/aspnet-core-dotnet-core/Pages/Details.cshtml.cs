using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using aspnet_core_dotnet_core.Data;
using aspnet_core_dotnet_core.repo;
using aspnet_core_dotnet_core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnet_core_dotnet_core.Pages
{
    public class Details : PageModel
    {
        public IList<Movie> movie;
        public IList<Ratings> ratings;
        public IList<People> actors;
        public IList<People> directors; 

        public RatingsServices RatingsServices;
        public MoviesService MoviesService;
        public ActorsService ActorsServices;
        public DirectorsService DirectorsService; 
        
        
        public void OnGet([FromRoute] int id )
        {
            RatingsServices = new RatingsServices();
            MoviesService = new MoviesService();
            ActorsServices = new ActorsService();
            DirectorsService = new DirectorsService(); 
            
            movie = new List<Movie>();
            ratings = new List<Ratings>();
            actors = new List<People>();
            directors = new List<People>(); 

            movie = MoviesService.searchMovieById(id);
            ratings = RatingsServices.searchMovieByName(id).ToList();
            actors = ActorsServices.searchMovieById(id).ToList();
            directors = DirectorsService.searchMovieById(id).ToList(); 


        }
    }
}