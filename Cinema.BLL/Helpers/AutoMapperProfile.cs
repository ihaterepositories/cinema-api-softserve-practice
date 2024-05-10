using System.Linq;
using AutoMapper;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.DTOs.ReservationDTOs;
using Cinema.Data.DTOs.ReservedSeatDTOs;
using Cinema.Data.DTOs.RoomsDTOs;
using Cinema.Data.DTOs.ScreeningDTOs;
using Cinema.Data.DTOs.SeatDTOs;
using Cinema.Data.Models;

namespace Cinema.BLL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // one-entity based mappings
            CreateMap<Actor, AddActorDto>().ReverseMap();
            CreateMap<Actor, GetActorDto>().ReverseMap();
            CreateMap<Actor, UpdateActorDto>().ReverseMap();

            CreateMap<Genre, AddGenreDto>().ReverseMap();
            CreateMap<Genre, GetGenreDto>().ReverseMap();
            CreateMap<Genre, UpdateGenreDto>().ReverseMap();

            CreateMap<Room, AddRoomDto>().ReverseMap();
            CreateMap<Room, GetRoomDto>()
                .ForMember(dest => dest.Seats, opt => opt.MapFrom(src => src.Seats))
                .ReverseMap();
            CreateMap<Room, UpdateRoomDto>().ReverseMap();

            CreateMap<ReservedSeat, AddReservedSeatDto>().ReverseMap();
            CreateMap<ReservedSeat, GetReservedSeatDto>().ReverseMap();

            CreateMap<Screening, AddScreeningDto>().ReverseMap();
            CreateMap<Screening, GetScreeningDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Movie, opt => opt.MapFrom(src => src.Movie))
                .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room))
                .ForMember(dest => dest.StartDateTime, opt => opt.MapFrom(src => src.StartDateTime))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
            CreateMap<Screening, UpdateScreeningDto>().ReverseMap();

            CreateMap<ReservedSeat, GetReservedSeatDto>();

            CreateMap<Seat, AddSeatDto>().ReverseMap();

            CreateMap<Seat, GetSeatDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Row, opt => opt.MapFrom(src => src.Row))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest.RoomId, opt => opt.MapFrom(src => src.RoomId))
                .ForMember(dest => dest.ReservedSeats, opt => opt.MapFrom(src => src.ReservedSeats));
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();
            //

            // multiple-entity based mappings for Movies
            CreateMap<Movie, GetMovieDto>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor)))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre)))
                .ReverseMap();

            CreateMap<AddMovieDto, Movie>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(actorDto => new MovieActor { ActorId = actorDto.ActorId })))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres.Select(genreDto => new MovieGenre { GenreId = genreDto.GenreId })))
                .ReverseMap();

            CreateMap<UpdateMovieDto, Movie>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres))
                .ReverseMap();
            CreateMap<AddMovieActorDto, MovieActor>();
            CreateMap<AddMovieGenreDto, MovieGenre>();
            //

            // for Reservation
            CreateMap<Reservation, GetReservationDto>()
               .ForMember(dest => dest.ReservedSeats, opt => opt.MapFrom(src => src.ReservedSeats))
               .ReverseMap();

            // CreateMap<Reservation, AddReservationDto>()
            //     .ForMember(dest => dest.ReservedSeats, opt => opt.MapFrom(src => src.ReservedSeats))
            //     .ForMember(dest => dest.ReservedSeats, opt => opt.MapFrom(src => src.ReservedSeats.Where(c => c.ReservationId == src.Id)))
            //     .ReverseMap();
            //
        }
    }
}