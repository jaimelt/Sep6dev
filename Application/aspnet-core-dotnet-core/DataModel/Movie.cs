using System;
using System.Text.Json.Serialization;

namespace aspnet_core_dotnet_core.Data
{
    public class Movie
    {


        
        [JsonPropertyName("id")]
        public int movieId { get; set; }

        [JsonPropertyName("title")]
        public string movieTitle { get; set; }

        [JsonPropertyName("year")]
        public int movieYear { get; set; }
    }
}
