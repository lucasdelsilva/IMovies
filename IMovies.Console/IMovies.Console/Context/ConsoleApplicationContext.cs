using IMovies.Console.Models;
using Microsoft.EntityFrameworkCore;

namespace IMovies.Console.Context
{
    public class ConsoleApplicationContext : DbContext
    {
        public ConsoleApplicationContext(DbContextOptions<ConsoleApplicationContext> options) : base(options) { }
        public DbSet<IMovieDetails> IMovieDetails { get; set; }
        public DbSet<IMovie> IMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Companies>().HasNoKey();
            modelBuilder.Entity<IMovieDetails>().OwnsOne(x => x.Companies);

            modelBuilder.Entity<Genres>().HasNoKey();
            modelBuilder.Entity<IMovieDetails>().OwnsOne(x => x.Genres);

            modelBuilder.Entity<Languages>().HasNoKey();
            modelBuilder.Entity<IMovieDetails>().OwnsOne(x => x.Languages);
        }
    }
}