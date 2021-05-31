using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using aspnet_core_dotnet_core.Data;


namespace aspnet_core_dotnet_core.repo
{
    public class StatisticsRepository
    {
        public const string dbConnectionString =
            "Server=tcp:sep6movies.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=Florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";

        public Movie[] getTop10VotedMovies()
        {
            ArrayList Movies = new ArrayList();
            Movie[] movieArr;
            try
            {
                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                   

                    String sql = "SELECT TOP(10) id,title,year,rating,votes FROM[dbo].[movies] as m join[ratings] as r on m.id = r.movie_id order by votes desc";

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
                                movie.rating = reader.GetDouble(index++);                              
                                movie.votes = reader.GetInt32(index++);
                                Movies.Add(movie);
                            }
                        }
                    }
                }

                if (Movies != null)
                {
                    movieArr = new Movie[Movies.Count];

                    if (Movies.Count != 0)
                    {
                        for (int i = 0; i < Movies.Count; i++)
                        {
                            movieArr[i] = (Movie)Movies[i];
                        }
                        return movieArr;
                    }
                }
                return new Movie[1];
              

               
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return new Movie[1];
            }
        }

      
        public Movie[] UsersFavourites()
        {

            ArrayList Movies = new ArrayList();
            Movie[] movieArr;

            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {
                    connection.Open();
                    String sql = " SELECT top(10) cast(title as varchar(30)), cast(user_email as varchar(30))   FROM[dbo].[listmovies] as l join movies as m on m.id = l.movie_id group by cast(title as varchar(30)),cast(user_email as varchar(30))";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int index = 0;
                                Movie movie = new Movie();

                                movie.movieTitle = reader.GetString(index++);
                                movie.email = reader.GetString(index++);
                                Movies.Add(movie);
                            }
                        }
                    }
                }

                if (Movies != null)
                {
                    movieArr = new Movie[Movies.Count];

                    if (Movies.Count != 0)
                    {
                        for (int i = 0; i < Movies.Count; i++)
                        {
                            movieArr[i] = (Movie)Movies[i];
                        }
                        return movieArr;
                    }
                }
                return new Movie[1];

            

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return new Movie[1];
            }
        }




    }
}


    
