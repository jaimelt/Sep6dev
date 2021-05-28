using System;
using System.Text.Json.Serialization;

namespace aspnet_core_dotnet_core.Data
{
    public class Movie
    {


        public int movieId { get; set; }

        public string movieTitle { get; set; }

        public int movieYear { get; set; }
    }
}
