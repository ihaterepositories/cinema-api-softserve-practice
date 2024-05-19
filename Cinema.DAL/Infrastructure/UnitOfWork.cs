using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories.Interfaces;

namespace Cinema.DAL.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly CinemaContext _cinemaContext;

    public IActorRepository ActorRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public IMovieActorRepository MovieActorRepository { get; }
    public IMovieGenreRepository MovieGenreRepository { get; }
    public IMovieRepository MovieRepository { get; }
    public IReservationRepository ReservationRepository { get; }
    public IReservedSeatRepository ReservedSeatRepository { get; }
    public IRoomRepository RoomRepository { get; }
    public IScreeningRepository ScreeningRepository { get; }
    public ISeatRepository SeatRepository { get; }
    public IUserRepository UserRepository { get; }
    public IUserRoleRepository UserRoleRepository { get; }
    
    public UnitOfWork
        (CinemaContext cinemaContext, 
        IActorRepository actorRepository, 
        IGenreRepository genreRepository, 
        IMovieActorRepository movieActorRepository, 
        IMovieGenreRepository movieGenreRepository, 
        IMovieRepository movieRepository, 
        IReservationRepository reservationRepository, 
        IReservedSeatRepository reservedSeatRepository, 
        IRoomRepository roomRepository, 
        IScreeningRepository screeningRepository, 
        ISeatRepository seatRepository, 
        IUserRepository userRepository, 
        IUserRoleRepository userRoleRepository)
    {
        _cinemaContext = cinemaContext;
        ActorRepository = actorRepository;
        GenreRepository = genreRepository;
        MovieActorRepository = movieActorRepository;
        MovieGenreRepository = movieGenreRepository;
        MovieRepository = movieRepository;
        ReservationRepository = reservationRepository;
        ReservedSeatRepository = reservedSeatRepository;
        RoomRepository = roomRepository;
        ScreeningRepository = screeningRepository;
        SeatRepository = seatRepository;
        UserRepository = userRepository;
        UserRoleRepository = userRoleRepository;
    }
    
    public async Task SaveChangesAsync()
    {
        await _cinemaContext.SaveChangesAsync();
    }
}