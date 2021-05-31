using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
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
        public IList<Comments> comments;

        public RatingsServices RatingsServices;
        public MoviesService MoviesService;
        public ActorsService ActorsServices;
        public DirectorsService DirectorsService;
        public CommentService CommentsService;
        public static int MovieID;

        private static HttpClient client = new HttpClient();
        public MovieDetails movieDetails;
        public LoginCredentials _loginCredentials;

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
            movieDetails = new MovieDetails();

        }


        public async Task OnGet([FromRoute] int id )
        {

            MovieID = id;

            movie = MoviesService.searchMovieById(MovieID);
            ratings = RatingsServices.searchMovieByName(MovieID).ToList();
            actors = ActorsServices.searchMovieById(MovieID).ToList();
            directors = DirectorsService.searchMovieById(id).ToList();
            comments = CommentsService.getAllComments(MovieID, _loginCredentials.email).ToList();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var streamTask = client.GetStreamAsync($"http://www.omdbapi.com/?apikey=49c14572&i=tt00{id}&plot=full");
            var options = new JsonSerializerOptions();
            MovieDetails m = await JsonSerializer.DeserializeAsync<MovieDetails>(await streamTask, options);

            movieDetails.Title = m.Title;
            movieDetails.Poster = m.Poster; 
            movieDetails.Year = m.Year; 
            movieDetails.Genre = m.Genre; 
            movieDetails.Plot = m.Plot; 
            movieDetails.Awards = m.Awards; 
            movieDetails.Country = m.Country;
            movieDetails.Language = m.Language;



        }

        public void OnPostSubmit(String Comment)
        {

            if (CommentsService != null)
            {
                CommentsService.postComment(MovieID, _loginCredentials.email, Comment);
            }
            OnGet(MovieID);


        }


    }
}