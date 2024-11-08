using IMovies.Console.DTOs;
using IMovies.Console.Models;
using Mapster;
using Microsoft.Extensions.DependencyInjection;

namespace IMovies.Console.Mappers
{
    public static class MapsterConfigurations
    {
        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<ResponseIMovieDetails, IMovieDetails>.NewConfig()
                .Map(dest => dest.Adulto, src => src.adult)
                .Map(dest => dest.BackGroundPath, src => src.backdrop_path)
                .Map(dest => dest.IMovieDb, src => src.imdb_id)
                //.Map(dest => dest.OriginCountry, src => src.origin_country.FirstOrDefault() ?? string.Empty)
                .Map(dest => dest.OriginCountry, src => string.Join(",", src.origin_country))
                .Map(dest => dest.OriginLanguage, src => src.original_language)
                .Map(dest => dest.OriginTitle, src => src.original_title)
                .Map(dest => dest.DescriptionMovie, src => src.overview)
                .Map(dest => dest.PosterPath, src => src.poster_path)
                .Map(dest => dest.ReleaseDate, src => src.release_date)
                .Map(dest => dest.TagLine, src => src.tagline)
                .Map(dest => dest.Title, src => src.title)
                .Map(dest => dest.VoteAverage, src => src.vote_average)
                .Map(dest => dest.VoteCount, src => src.vote_count)
                .Map(dest => dest.Genres, src => src.genres)
                .Map(dest => dest.Languages, src => src.spoken_languages)
                .Map(dest => dest.Companies, src => src.production_companies);

            TypeAdapterConfig<Genre, Genres>.NewConfig()
                    .Map(dest => dest.value, src => src.id)
                    .Map(dest => dest.Description, src => src.name);

            TypeAdapterConfig<SpokenLanguage, Languages>.NewConfig()
                    .Map(dest => dest.NameLanguage, src => src.english_name)
                    .Map(dest => dest.Name, src => src.name)
                    .Map(dest => dest.CodeName, src => src.iso_639_1);

            TypeAdapterConfig<ProductionCompany, Companies>.NewConfig()
                    .Map(dest => dest.Name, src => src.name)
                    .Map(dest => dest.value, src => src.id)
                    .Map(dest => dest.LogoPath, src => src.logo_path)
                    .Map(dest => dest.Country, src => src.origin_country);

        }
    }
}