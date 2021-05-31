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
        [BindProperty]
        public string SearchString { get; set; }
        [BindProperty]
        public string SearchStringActor { get; set; }
        [BindProperty]
        public string SearchStringDirector { get; set; }
        public IList<Movie> listMovies { get; set;  }

        public MoviesService moviesService;

        public LoginCredentials loginCredentials;

        public  Index(LoginCredentials loginCredentials)
        {
            this.loginCredentials = loginCredentials; 
        }
        
        public void OnGet()
        {
            moviesService = new MoviesService();
            listMovies = new List<Movie>(); 
            listMovies = moviesService.GetAllMovies(); 

        }
    
        public void OnPostSubmit()
        {           
            moviesService = new MoviesService();
            listMovies = moviesService.searchMovieByName(SearchString).ToList();
       
        }
        
        public void OnPostRegister()
        {
           
            moviesService = new MoviesService();
            listMovies = moviesService.searchMovieByActor(SearchStringActor).ToList();

        }
        
        public void OnPostSearch()
        {
            Console.WriteLine(SearchStringDirector);
            moviesService = new MoviesService();
            listMovies = moviesService.searchMovieByDirector(SearchStringDirector).ToList();
            
        }
        
        

       
      
    }
}