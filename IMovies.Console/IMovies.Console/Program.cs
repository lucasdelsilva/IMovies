using IMovies.Console.Context;
using IMovies.Console.DTOs;
using IMovies.Console.Mappers;
using IMovies.Console.Models;
using Mapster;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System.Drawing;

internal class Program
{
    private static void Main(string[] args)
    {
        Random res = new Random();
        var list = new List<string>()
        {
            "Moviezz", //1
            "yMovie", //2
            "yFilm"  //3
        };
        int size = 9230;
        String ran = "";
        for (int i = 0; i < size; i++)
        {

            // Selecting a index randomly 
            int x = res.Next(0, 4);
            Console.WriteLine(x);
            // Appending the character at the  
            // index to the random string. 
            ran = ran + x;
        }
        Console.WriteLine(ran + "é esse nome;");
        Console.ReadKey();
        return;
    }

    //private static async Task Main(string[] args)
    //{
    //    //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false);
    //    var builder = Host.CreateDefaultBuilder(args);

    //    builder.ConfigureAppConfiguration(configurationBuilder =>
    //     {
    //         configurationBuilder.AddJsonFile(
    //             "appsettings.json",
    //             optional: false
    //         );
    //         configurationBuilder.AddEnvironmentVariables();
    //         configurationBuilder.AddCommandLine(args);

    //     }).ConfigureServices(
    //        (hostContext, services) =>
    //        {
    //            var configuration = hostContext.Configuration;
    //            var sections = configuration.GetSection("Movies");
    //            services.RegisterMaps();
    //        });

    //    var host = builder.Build();

    //    if (!await AuthenticationAsync())
    //    {
    //        Console.WriteLine("1. Usuário Autenticado.");
    //        Console.WriteLine("2. Por favor, verifique suas credencias no site 'https://api.themoviedb.org/3/authentication'.");

    //        Console.ReadKey();
    //    }

    //    var movieDetails = new List<ResponseIMovieDetails>();
    //    int pageSize = 2;

    //    var listTopRated = await TopRated(movieDetails, pageSize);


    //    var listPlaying = await NowPlayingAsync(movieDetails, pageSize);

    //    var listUpComing = await UpComing(movieDetails, pageSize);
    //    var listPopular = await Popular(movieDetails, pageSize);

    //    var saveMoviesDb = movieDetails.Adapt<List<IMovieDetails>>();
    //    if (saveMoviesDb.Count > 0)
    //    {
    //        using (var context = new ConsoleApplicationContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ConsoleApplicationContext>()))
    //        {
    //            await context.IMovieDetails.AddRangeAsync(saveMoviesDb);
    //            await context.SaveChangesAsync();

    //            Console.WriteLine();
    //            Console.WriteLine(saveMoviesDb.Count + ": Filmes Adicionados");
    //            Console.ReadKey();
    //        }
    //    }

    //    async Task<List<ResponseIMovieDetails>> TopRated(List<ResponseIMovieDetails> movieDetails, int pageSize)
    //    {
    //        var client = new HttpClient();
    //        int index = 1;

    //        var model = new ResponseIMovie();
    //        while (!index.Equals(model.total_pages))
    //        {
    //            if (index > pageSize)
    //                break;

    //            var request = new HttpRequestMessage
    //            {
    //                Method = HttpMethod.Get,
    //                RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + ListTypeMovies.TopRated + "?language=pt-BR&page=" + index + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                Headers =
    //                {
    //                    { "accept", "application/json" },
    //                    { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ" },
    //                },
    //            };
    //            using (var response = await client.SendAsync(request))
    //            {
    //                var body = await response.Content.ReadAsStringAsync();
    //                model = JsonConvert.DeserializeObject<ResponseIMovie>(body);

    //                foreach (var item in model.results)
    //                {
    //                    //https://api.themoviedb.org/3/movie/1022789?language=en-US&api_key=1ffcb024883a1f21cab3b19689d51519

    //                    var reqMovie = new HttpRequestMessage
    //                    {
    //                        Method = HttpMethod.Get,
    //                        RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + item.id + "?language=pt-BR" + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                        Headers =
    //            {
    //                { "accept", "application/json" },
    //                { "Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ"},
    //            },
    //                    };

    //                    using (var responseMovie = await client.SendAsync(reqMovie))
    //                    {
    //                        responseMovie.EnsureSuccessStatusCode();
    //                        var resModel = await responseMovie.Content.ReadAsStringAsync();
    //                        var movie = JsonConvert.DeserializeObject<ResponseIMovieDetails>(resModel);

    //                        if (movie.release_date is null)
    //                        {
    //                            continue;
    //                        }

    //                        movieDetails.Add(movie);
    //                        Console.WriteLine("------------------------------Adicionado a lista------------------------------");
    //                        Console.WriteLine();
    //                        Console.WriteLine(movie.title);
    //                        Console.WriteLine();
    //                        Console.WriteLine("---------------------------------------TOP RATED---------------------------------------");
    //                    }
    //                };

    //                index = index + 1;
    //            }
    //        }

    //        return movieDetails;
    //    }

    //    async Task<List<ResponseIMovieDetails>> NowPlayingAsync(List<ResponseIMovieDetails> movieDetails, int pageSize)
    //    {
    //        var client = new HttpClient();
    //        int index = 1;

    //        var model = new ResponseIMovie();
    //        while (!index.Equals(model.total_pages))
    //        {
    //            if (index > pageSize)
    //                break;

    //            var request = new HttpRequestMessage
    //            {
    //                Method = HttpMethod.Get,
    //                RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + ListTypeMovies.NowPlaying + "?language=pt-BR&page=" + index + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                Headers =
    //            {
    //                { "accept", "application/json" },
    //                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ" },
    //            },
    //            };
    //            using (var response = await client.SendAsync(request))
    //            {
    //                var body = await response.Content.ReadAsStringAsync();
    //                model = JsonConvert.DeserializeObject<ResponseIMovie>(body);

    //                foreach (var item in model.results)
    //                {
    //                    //https://api.themoviedb.org/3/movie/1022789?language=en-US&api_key=1ffcb024883a1f21cab3b19689d51519

    //                    var reqMovie = new HttpRequestMessage
    //                    {
    //                        Method = HttpMethod.Get,
    //                        RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + item.id + "?language=pt-BR" + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                        Headers =
    //                    {
    //                        { "accept", "application/json" },
    //                        { "Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ"},
    //                    },
    //                    };

    //                    using (var responseMovie = await client.SendAsync(reqMovie))
    //                    {
    //                        responseMovie.EnsureSuccessStatusCode();
    //                        var resModel = await responseMovie.Content.ReadAsStringAsync();
    //                        var movie = JsonConvert.DeserializeObject<ResponseIMovieDetails>(resModel);


    //                        movieDetails.Add(movie);
    //                        Console.WriteLine("------------------------------Adicionado a lista------------------------------");
    //                        Console.WriteLine();
    //                        Console.WriteLine(movie.title);
    //                        Console.WriteLine();
    //                        Console.WriteLine("---------------------------------------NowPlaying---------------------------------------");
    //                    }
    //                };

    //                index = index + 1;
    //            }
    //        }

    //        return movieDetails;
    //    }

    //    async Task<List<ResponseIMovieDetails>> UpComing(List<ResponseIMovieDetails> movieDetails, int pageSize)
    //    {
    //        var client = new HttpClient();
    //        int index = 1;

    //        var model = new ResponseIMovie();
    //        while (!index.Equals(model.total_pages))
    //        {
    //            if (index > pageSize)
    //                break;

    //            var request = new HttpRequestMessage
    //            {
    //                Method = HttpMethod.Get,
    //                RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + ListTypeMovies.UpComing + "?language=pt-BR&page=" + index + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                Headers =
    //            {
    //                { "accept", "application/json" },
    //                { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ" },
    //            },
    //            };
    //            using (var response = await client.SendAsync(request))
    //            {
    //                var body = await response.Content.ReadAsStringAsync();
    //                model = JsonConvert.DeserializeObject<ResponseIMovie>(body);

    //                foreach (var item in model.results)
    //                {
    //                    //https://api.themoviedb.org/3/movie/1022789?language=en-US&api_key=1ffcb024883a1f21cab3b19689d51519

    //                    var reqMovie = new HttpRequestMessage
    //                    {
    //                        Method = HttpMethod.Get,
    //                        RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + item.id + "?language=pt-BR" + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                        Headers =
    //                    {
    //                        { "accept", "application/json" },
    //                        { "Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ"},
    //                    },
    //                    };

    //                    using (var responseMovie = await client.SendAsync(reqMovie))
    //                    {
    //                        responseMovie.EnsureSuccessStatusCode();
    //                        var resModel = await responseMovie.Content.ReadAsStringAsync();
    //                        var movie = JsonConvert.DeserializeObject<ResponseIMovieDetails>(resModel);

    //                        movieDetails.Add(movie);
    //                        Console.WriteLine("------------------------------Adicionado a lista------------------------------");
    //                        Console.WriteLine();
    //                        Console.WriteLine(movie.title);
    //                        Console.WriteLine();
    //                        Console.WriteLine("--------------------------------------UpComing----------------------------------------");
    //                    }
    //                };

    //                index = index + 1;
    //            }
    //        }

    //        return movieDetails;
    //    }

    //    async Task<List<ResponseIMovieDetails>> Popular(List<ResponseIMovieDetails> movieDetails, int pageSize)
    //    {
    //        var client = new HttpClient();
    //        int index = 1;

    //        var model = new ResponseIMovie();
    //        while (!index.Equals(model.total_pages))
    //        {
    //            if (index > pageSize)
    //                break;

    //            var request = new HttpRequestMessage
    //            {
    //                Method = HttpMethod.Get,
    //                RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + ListTypeMovies.Popular + "?language=pt-BR&page=" + index + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                Headers =
    //    {
    //        { "accept", "application/json" },
    //        { "Authorization", "Bearer eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ" },
    //    },
    //            };
    //            using (var response = await client.SendAsync(request))
    //            {
    //                var body = await response.Content.ReadAsStringAsync();
    //                model = JsonConvert.DeserializeObject<ResponseIMovie>(body);
    //                if (model.results is not null)
    //                {

    //                    foreach (var item in model.results)
    //                    {
    //                        //https://api.themoviedb.org/3/movie/1022789?language=en-US&api_key=1ffcb024883a1f21cab3b19689d51519

    //                        var reqMovie = new HttpRequestMessage
    //                        {
    //                            Method = HttpMethod.Get,
    //                            RequestUri = new Uri("https://api.themoviedb.org/3/movie/" + item.id + "?language=pt-BR" + "&api_key=1ffcb024883a1f21cab3b19689d51519"),
    //                            Headers =
    //                            {
    //                                { "accept", "application/json" },
    //                                { "Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ"},
    //                            },
    //                        };

    //                        using (var responseMovie = await client.SendAsync(reqMovie))
    //                        {
    //                            responseMovie.EnsureSuccessStatusCode();
    //                            var resModel = await responseMovie.Content.ReadAsStringAsync();
    //                            var movie = JsonConvert.DeserializeObject<ResponseIMovieDetails>(resModel);

    //                            movieDetails.Add(movie);
    //                            Console.WriteLine("------------------------------Adicionado a lista------------------------------");
    //                            Console.WriteLine();
    //                            Console.WriteLine(movie.title);
    //                            Console.WriteLine();
    //                            Console.WriteLine("--------------------------------------Popular----------------------------------------");
    //                        }
    //                    }
    //                };

    //                index = index + 1;
    //            }
    //        }

    //        return movieDetails;
    //    }

    //    async Task<bool> AuthenticationAsync()
    //    {
    //        var client = new HttpClient();
    //        var request = new HttpRequestMessage
    //        {
    //            Method = HttpMethod.Get,
    //            RequestUri = new Uri("https://api.themoviedb.org/3/authentication"),
    //            Headers =
    //        {
    //            { "accept", "application/json" },
    //            { "Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiIxZmZjYjAyNDg4M2ExZjIxY2FiM2IxOTY4OWQ1MTUxOSIsIm5iZiI6MTcyMDM2MjgxMi4xNzA2MjcsInN1YiI6IjY2ODg3YjVmYjlmNmJlZmFlYjE3ZTdkYSIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.5_5XFCfoTLEOzK2Z7PK6P-0gibkT7kEvS3yaNMLvWAQ"},
    //        },
    //        };
    //        using (var response = await client.SendAsync(request))
    //        {
    //            response.EnsureSuccessStatusCode();
    //            var body = await response.Content.ReadAsStringAsync();
    //            var model = JsonConvert.DeserializeObject<ResponseStatus>(body);

    //            if (model.Success)
    //            {
    //                Console.WriteLine("Usuário Autenticado.");
    //                Console.WriteLine(model.Status_message);

    //                return true;
    //            }

    //            return false;
    //        }
    //    }
    //}
}