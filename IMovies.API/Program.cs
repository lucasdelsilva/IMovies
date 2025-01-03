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
using IMovies.Console.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigurationApplicationServices(builder);
        ConfigurationInterfaces(builder);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Mevam API",
                Version = "v1"
            });

            opt.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new List<string>{}
        }
    });
        });

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

    private static void ConfigurationApplicationServices(WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IValidator<CreateOrUpdateMovieDto>, MovieValidator>();
        builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterValidator>();
        builder.Services.AddScoped<IValidator<AuthenticationDto>, LoginValidator>();

        builder.Services.AddDbContext<ApplicationContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionApplication")));

        builder.Services.AddDbContext<ConsoleApplicationContext>(options =>
                       options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionApplication"), b => b.MigrationsAssembly("IMovies.API")));

        builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        builder.Services.RegisterMaps();
    }
}