using FluentValidation;
using IMovies.API.Context;
using IMovies.API.Domain.Models;
using IMovies.API.Domain.Services;
using IMovies.API.Domain.Services.Authentication;
using IMovies.API.Domain.Services.Authentication.Token;
using IMovies.API.Domain.Services.Interfaces;
using IMovies.API.DTOs;
using IMovies.API.DTOs.Movie;
using IMovies.API.DTOs.User;
using IMovies.API.Helper.Validations;
using IMovies.API.Mappers;
using IMovies.API.Repositories;
using IMovies.API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    [Obsolete]
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationApplicationServices(builder);
        ConfigurationInterfaces(builder);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }

    private static void ConfigurationInterfaces(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IAuthenticationServices, AuthenticationServices>();
        builder.Services.AddScoped<ITokenServices, TokenServices>();

        builder.Services.AddScoped<IMovieServices, MovieServices>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();

        builder.Services.AddScoped<IUserServices, UserServices>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }

    [Obsolete]
    private static void ConfigurationApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IValidator<AuthenticationDto>, AuthenticationValidator>();
        builder.Services.AddScoped<IValidator<CreateOrUpdateMovieDto>, MovieValidator>();
        builder.Services.AddScoped<IValidator<RegisterUserDto>, UserValidator>();

        builder.Services.AddDbContext<ApplicationContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionApplication")));

        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        builder.Services.RegisterMaps();
    }
}