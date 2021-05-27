using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using aspnet_core_dotnet_core.Data;


namespace aspnet_core_dotnet_core.repo
{
    public class MoviesRepo
    {

        private const string dbConnectionString = "Server=tcp:sep6movies.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=Florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";
        
        public ArrayList GetMovies()
        {
            ArrayList Movies = new ArrayList();
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                    
                    String sql = "SELECT TOP (100) * FROM [dbo].[movies]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();
                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);

                                Console.WriteLine(movie.movieTitle);
                                Console.WriteLine(movie.movieId);
                                Console.WriteLine(movie.movieYear);
                                Movies.Add(movie);
                            }
                        }
                    }
                }
                return Movies;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Movies;
            }
        }

        public IEnumerable<Movie> SearchMovieByName(string movieName)
        {
            List<Movie> Movies = new List<Movie>();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                { 
                    connection.Open();
                    
                    String sql = "SELECT TOP (100) * FROM [dbo].[movies]";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();
                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);

                                Movies.Add(movie);
                                
                            }
                        }
                    }
                }

                var searchedMovie = from Movie movie in Movies where movie.movieTitle.Equals(movieName) select movie;
                

                return searchedMovie; 

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        }


    }
