using Bogus;
using Cinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.DAL.Seeding
{
    public static class CinemaSeeding
    {
        public static List<Actor> Actors { get; set; } = new();
        public static List<Genre> Genres { get; set; } = new();
        public static List<Movie> Movies { get; set; } = new();
        public static List<MovieActor> MovieActors { get; set; } = new();
        public static List<MovieGenre> MovieGenres { get; set; } = new();
        public static List<Reservation> Reservations { get; set; } = new();
        public static List<ReservedSeat> ReservedSeats { get; set; } = new();
        public static List<Room> Rooms { get; set; } = new();
        public static List<Screening> Screenings { get; set; } = new();
        public static List<Seat> Seats { get; set; } = new();
        public static List<User> Users { get; set; } = new();
        public static List<UserRole> UserRoles { get; set; } = new();

        public static void SeedingInit()
        {
            Actors=new Faker<Actor>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x=>x.FullName,f=>f.Name.FullName())
                .RuleFor(x=>x.Description,f=>f.Lorem.Sentences())
                .RuleFor(x=>x.Photo,f=>f.Internet.Url())
                .Generate(30);

             Genres = new Faker<Genre>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x=>x.GenreName, f => f.Music.Genre())
                .Generate(30);

            Movies = new Faker<Movie>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Name, f => f.Name.Random.Word())
                .RuleFor(x => x.ReleaseDate, f => f.Date.PastDateOnly())
                .RuleFor(x => x.Rating, f => f.Random.Number(10))
                .RuleFor(x => x.StartAiringDate, f => f.Date.PastDateOnly())
                .RuleFor(x => x.EndAiringDate, f => f.Date.FutureDateOnly())
                .RuleFor(x => x.Description, f => f.Lorem.Sentences())
                .RuleFor(x => x.Trailer, f => f.Internet.Url())
                .RuleFor(x => x.Duration, f => f.Date.RecentTimeOnly())
                .RuleFor(x => x.Photo, f => f.Internet.Url())
                .Generate(30);

            MovieActors=new Faker<MovieActor>()
                .Generate(30);

            MovieGenres = new Faker<MovieGenre>()
                .Generate(30);

            Reservations = new Faker<Reservation>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Reserved, f => f.Random.Bool())
                .RuleFor(x => x.IsPaid, f => f.Random.Bool())
                .RuleFor(x => x.IsActive, f => f.Random.Bool())
                .Generate(30);

            ReservedSeats = new Faker<ReservedSeat>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .Generate(30);

            Rooms = new Faker<Room>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.RoomName, f => f.Lorem.Word())
                .RuleFor(x => x.NumberOfSeats, f => f.Random.Int())
                .Generate(30);

            Screenings = new Faker<Screening>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.ScreeningStart, f => f.Date.RecentTimeOnly())
                .RuleFor(x => x.Price, f => f.Random.Double())
                .Generate(30);

            Seats = new Faker<Seat>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.Row, f => f.Random.Int())
                .RuleFor(x => x.Number, f => f.Random.Int())
                .Generate(30);

            Users=new Faker<User>()
                .RuleFor(x => x.Id, f => f.Random.Guid())
                .RuleFor(x => x.UserName, f => f.Internet.UserName())
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.PasswordHash, f => f.Internet.Password())
                .Generate(30);

            UserRoles = new List<UserRole>()
            {
                new UserRole()
                {
                    Id=Guid.NewGuid(),
                    Name = "admin"
                },
                new UserRole()
                {
                    Id = Guid.NewGuid(),
                    Name="user"
                }
            };

            for (int i = 0; i < 30; i++)
            {
                var random = new Random();

                MovieActors[i].MovieId = Movies[i].Id;
                MovieActors[i].ActorId = Actors[i].Id;

                MovieGenres[i].MovieId = Movies[i].Id;
                MovieGenres[i].GenreId = Genres[i].Id;

                Reservations[i].UserId = Users[random.Next(Users.Count)].Id;

                ReservedSeats[i].SeatId = Seats[random.Next(Seats.Count)].Id;
                ReservedSeats[i].ReservationId = Reservations[random.Next(Reservations.Count)].Id;
                ReservedSeats[i].ScreeningId = Screenings[random.Next(Screenings.Count)].Id;

                Screenings[i].MovieId = Movies[random.Next(Movies.Count)].Id;
                Screenings[i].RoomId = Rooms[random.Next(Rooms.Count)].Id;

                Seats[i].RoomId = Rooms[random.Next(Rooms.Count)].Id;
            }
        }
    }
}
