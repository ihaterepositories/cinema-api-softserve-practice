using Cinema.DAL.Repositories.Interfaces;

namespace Cinema.DAL.Infrastructure.Interfaces;

public interface IUnitOfWork
{
    IActorRepository ActorRepository { get; }
    IGenreRepository GenreRepository { get; }
    IMovieActorRepository MovieActorRepository { get; }
    IMovieGenreRepository MovieGenreRepository { get; }
    IMovieRepository MovieRepository { get; }
    IReservationRepository ReservationRepository { get; }
    IReservedSeatRepository ReservedSeatRepository { get; }
    IRoomRepository RoomRepository { get; }
    IScreeningRepository ScreeningRepository { get; }
    ISeatRepository SeatRepository { get; }
    IUserRepository UserRepository { get; }
    IUserRoleRepository UserRoleRepository { get; }
    
    Task SaveChangesAsync();
}