using System.Reflection;
using Cinema.DAL.Seeding;
using Cinema.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.DAL;

public class CinemaContext : IdentityDbContext<User,UserRole,Guid>
{
    public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) 
    {
        Database.EnsureCreated();
    }
    
    public DbSet<Actor> Actors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieActor> MovieActors { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Screening> Screenings { get; set; }
    public DbSet<Seat> Seats { get; set; }
    public DbSet<ReservedSeat> ReservedSeats { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        modelBuilder.Entity<IdentityUserLogin<Guid>>().HasNoKey();
        modelBuilder.Entity<IdentityUserRole<Guid>>().HasNoKey();
        modelBuilder.Entity<IdentityUserToken<Guid>>().HasNoKey();

        ConfigureSeeding(modelBuilder);
    }

    private void ConfigureSeeding(ModelBuilder modelBuilder)
    {
        CinemaSeeding.SeedingInit();
        modelBuilder.Entity<Actor>().HasData(CinemaSeeding.Actors);
        modelBuilder.Entity<Genre>().HasData(CinemaSeeding.Genres);
        modelBuilder.Entity<Movie>().HasData(CinemaSeeding.Movies);
        modelBuilder.Entity<MovieActor>().HasData(CinemaSeeding.MovieActors);
        modelBuilder.Entity<MovieGenre>().HasData(CinemaSeeding.MovieGenres);
        modelBuilder.Entity<Reservation>().HasData(CinemaSeeding.Reservations);
        modelBuilder.Entity<Room>().HasData(CinemaSeeding.Rooms);
        modelBuilder.Entity<Screening>().HasData(CinemaSeeding.Screenings);
        modelBuilder.Entity<Seat>().HasData(CinemaSeeding.Seats);
        modelBuilder.Entity<ReservedSeat>().HasData(CinemaSeeding.ReservedSeats);
        modelBuilder.Entity<User>().HasData(CinemaSeeding.Users);
        modelBuilder.Entity<UserRole>().HasData(CinemaSeeding.UserRoles);
    }
}