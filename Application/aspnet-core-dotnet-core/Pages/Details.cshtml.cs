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
        public LoginCredentials _loginCredentials;
        public IList<Movie> movie;
        public IList<Ratings> ratings;
        public IList<People> actors;
        public IList<People> directors;
        public IList<Comments> comments;

        public RatingsServices RatingsServices;
        public MoviesService MoviesService;
        public ActorsService ActorsServices;
        public DirectorsService DirectorsService;
        public CommentService CommentsService;
        public static int MovieID;
        public Details(LoginCredentials loginCredentials) 
        {
            _loginCredentials = loginCredentials;
            RatingsServices = new RatingsServices();
            MoviesService = new MoviesService();
            ActorsServices = new ActorsService();
            DirectorsService = new DirectorsService();
            CommentsService = new CommentService();

            movie = new List<Movie>();
            ratings = new List<Ratings>();
            actors = new List<People>();
            directors = new List<People>();

        }
    


     




        public void OnGet([FromRoute] int id )
        {
            System.Diagnostics.Debug.WriteLine("--------------------"+ id);
            MovieID = id;
            movie = MoviesService.searchMovieById(MovieID);
            ratings = RatingsServices.searchMovieByName(MovieID).ToList();
            actors = ActorsServices.searchMovieById(MovieID).ToList();
            directors = DirectorsService.searchMovieById(MovieID).ToList();
            comments = CommentsService.getAllComments(MovieID, _loginCredentials.email).ToList();

        }

        public  void OnPostSubmit(String Comment)
        {
            
            if (CommentsService!=null)
            {
                CommentsService.postComment(MovieID, _loginCredentials.email, Comment);
            }
            OnGet(MovieID);
            

        }
    }
}