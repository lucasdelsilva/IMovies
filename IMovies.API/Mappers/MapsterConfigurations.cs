using IMovies.API.Domain.Models;
using IMovies.API.DTOs.Movie;
using IMovies.API.DTOs.User;
using Mapster;

namespace IMovies.API.Mappers
{
    public static class MapsterConfigurations
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            //Filmes
            TypeAdapterConfig<CreateOrUpdateMovieDto, Movie>.NewConfig();
            TypeAdapterConfig<Movie, CreateOrUpdateMovieDto>.NewConfig();
            TypeAdapterConfig<Movie, MovieResponseDto>.NewConfig();

            //Usuario
            TypeAdapterConfig<RegisterUserDto, User>.NewConfig();
            TypeAdapterConfig<User, RegisterUserDto>.NewConfig();
        }
    }
}