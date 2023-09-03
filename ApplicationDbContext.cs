using EFCoreMovies.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMovies
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        //used to override convention
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Genre>().Property(p => p.Name).HasMaxLength(150).IsRequired(); ;
            modelBuilder.Entity<Genre>().Property(p => p.Name).IsRequired(); ;

            modelBuilder.Entity<Actor>().Property(p => p.Name).IsRequired(); ;
            modelBuilder.Entity<Actor>().Property(p => p.Biography).HasColumnType("nvarchar(max)");
            //modelBuilder.Entity<Actor>().Property(p => p.DateOfBirth).HasColumnType("date");

            modelBuilder.Entity<Cinema>().Property(p => p.Name).IsRequired(); ;

            modelBuilder.Entity<CinemaHall>().Property(p => p.Cost).HasPrecision(precision: 9, scale: 2);
            modelBuilder.Entity<CinemaHall>().Property(p => p.CinemaHallType).HasDefaultValue(CinemaHallType.TwoDimensions);

            modelBuilder.Entity<Movie>().Property(p => p.Title).HasMaxLength(250).IsRequired(); ;

            //characters accept, no emoijis
            modelBuilder.Entity<Movie>().Property(p => p.PosterURL).HasMaxLength(500).IsUnicode(false);

            modelBuilder.Entity<CinemaOffer>().Property(p => p.DiscountPercentage).HasPrecision(5, 2);

            modelBuilder.Entity<MovieActor>().HasKey(p => new { p.MovieId, p.ActorId });

        }

        //needs to do remove-database, also require to query thru DBContext
        public DbSet <Genre> Genres { get; set; }
        public DbSet <Actor> Actors { get; set; }
        public DbSet <Cinema> Cinemas { get; set; }
        public DbSet <Movie> Movies { get; set; }
        public DbSet <CinemaOffer> CinemaOffers { get; set; }
        public DbSet <CinemaHall> CinemaHalls { get; set; }
        public DbSet <MovieActor> MovieActors { get; set; }

    }
}
