using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using aspnet_core_dotnet_core.Data;

namespace aspnet_core_dotnet_core.repo
{
    class MoviesRepo
    {

        private const string dbConnectionString = "Server=tcp:sep6db.database.windows.net,1433;Initial Catalog=movies;Persist Security Info=False;User ID=sep6;Password=florin123.;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30; ";
        
        public ArrayList GetMovies()
        {
            

            ArrayList Movies = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {

                    connection.Open();
                    
                    

                    String sql = "SELECT TOP (200) * FROM [dbo].[movies]";

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
                return Movies;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Movies;
            }
        }

        public ArrayList SearchMovieByName(string movieName)
        {


            ArrayList Movies = new ArrayList();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {

                    connection.Open();



                    String sql = "SELECT TOP (200) * FROM [dbo].[movies] where name ="+movieName+"";

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
                return Movies;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return Movies;
            }
        }

        public Movie GetMovieFullDetails(string movieName)
        {

            Movie movie = new Movie();
            try
            {

                using (SqlConnection connection = new SqlConnection(MoviesRepo.dbConnectionString))
                {

                    connection.Open();


                    /* we need to do joins here join comments join all*/
                    String sql = "SELECT TOP (200) * FROM [dbo].[movies] where name =" + movieName + "";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                int index = 0;                            
                                movie.movieId = reader.GetInt32(index++);
                                movie.movieTitle = reader.GetString(index++);
                                movie.movieYear = reader.GetInt32(index++);


                               
                               

                            }



                        }
                    }
                }
                return movie;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
                return movie;
            }
        }

    }
}