using IMovies.Console.DTOs;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);
var config = builder.Build();

var sections = config.GetSection("Movies");


if (!await AuthenticationAsync(sections))
{
    Console.WriteLine("1. Usuário Autenticado.");
    Console.WriteLine("2. Por favor, verifique suas credencias no site 'https://api.themoviedb.org/3/authentication'.");

    Console.ReadKey();
}

var movieDetails = new List<ResponseIMovieDetails>();

var listPlaying = await NowPlayingAsync(sections, movieDetails);

async Task<List<ResponseIMovieDetails>> NowPlayingAsync(IConfiguration _config, List<ResponseIMovieDetails> movieDetails)
{
    var client = new HttpClient();
    int index = 1;

    var model = new ResponseIMovie();
    while (!index.Equals(model.total_pages))
    {
        if (index > 500)
            break;

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(_config["MoviesUrl"] + ListTypeMovies.NowPlaying + "?language=pt-BR&page=" + index + _config["ApiKeyAuth"]),
            Headers =
                {
                    { "accept", "application/json" },
                    { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ" },
                },
        };
        using (var response = await client.SendAsync(request))
        {
            var body = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<ResponseIMovie>(body);

            foreach (var item in model.results)
            {
                //https://api.themoviedb.org/3/movie/1022789?language=en-US&api_key=1ffcb024883a1f21cab3b19689d51519

                var reqMovie = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(_config["MoviesUrl"] + item.id + "?language=pt-BR" + _config["ApiKeyAuth"]),
                    Headers =
                        {
                            { "accept", "application/json" },
                            { "Authorization", "Bearer " + _config["AccessTokenAuth"]},
                        },
                };

                using (var responseMovie = await client.SendAsync(reqMovie))
                {
                    responseMovie.EnsureSuccessStatusCode();
                    var resModel = await responseMovie.Content.ReadAsStringAsync();
                    var movie = JsonConvert.DeserializeObject<ResponseIMovieDetails>(resModel);

                    movieDetails.Add(movie);
                    Console.WriteLine("------------------------------Adicionado a lista------------------------------");
                    Console.WriteLine(movie.title);
                    Console.WriteLine("------------------------------------------------------------------------------");
                }
            };

            index = index + 1;
        }
    }

    return movieDetails;
}

async Task<bool> AuthenticationAsync(IConfiguration _config)
{
    var client = new HttpClient();
    var request = new HttpRequestMessage
    {
        Method = HttpMethod.Get,
        RequestUri = new Uri("https://api.themoviedb.org/3/authentication"),
        Headers =
            {
                { "accept", "application/json" },
                { "Authorization", "Bearer " + _config["AccessTokenAuth"]},
            },
    };
    using (var response = await client.SendAsync(request))
    {
        response.EnsureSuccessStatusCode();
        var body = await response.Content.ReadAsStringAsync();
        var model = JsonConvert.DeserializeObject<ResponseStatus>(body);

        if (model.Success)
        {
            Console.WriteLine("Usuário Autenticado.");
            Console.WriteLine(model.Status_message);

            return true;
        }

        return false;
    }
}
