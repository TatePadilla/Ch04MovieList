using Microsoft.EntityFrameworkCore;
using MovieList.Models;

namespace Ch04MovieList.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        { }
        public DbSet<Movie> Movies { get; set; } = null!;
        
        // Any new entities (Genres) must be added to the DbContext class as DbSet properties.
        public DbSet<Genre> Genres { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Setting intial seed data (NOT REQUIRED).
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = "A", Name = "Action" }, 
                new Genre { GenreId = "C", Name = "Comedy" }, 
                new Genre { GenreId = "D", Name = "Drama" }, 
                new Genre { GenreId = "H", Name = "Horror" }, 
                new Genre { GenreId = "M", Name = "Musical" }, 
                new Genre { GenreId = "R", Name = "RomCom" }, 
                new Genre { GenreId = "S", Name = "SciFi" }
            ); 
            
            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    // Setting intial seed data (NOT REQUIRED).
                    MovieId = 1,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreId = "D"
                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = "A"
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = "R"
                }
            );
        }
    }
}
