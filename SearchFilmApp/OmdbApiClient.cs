using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace SearchFilmApp
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string Type { get; set; }
        public string PosterUrl { get; set; }
    }

    public static class MovieService
    {
        private const string ApiKey = "e477f1b5";
        private const string BaseUrl = "http://www.omdbapi.com/";

        public static async Task<Movie> GetMovieAsync(string title, int year, string type)
        {
            using (var client = new HttpClient())
            {
                var url = $"{BaseUrl}?apikey={ApiKey}&t={title}&y={year}&type={type}";

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var movie = JsonConvert.DeserializeObject<Movie>(json);
                    return movie;
                }
                else
                {
                    throw new HttpRequestException($"Failed to retrieve movie. Status code: {response.StatusCode}");
                }
            }
        }
    }
}
