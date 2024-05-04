using System.Linq;
using AutoMapper;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.DTOs.ReservedSeatDTOs;
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

            CreateMap<ReservedSeat, AddReservedSeatDto>().ReverseMap();
            CreateMap<ReservedSeat, GetReservedSeatDto>().ReverseMap();

            CreateMap<Screening, AddScreeningDto>().ReverseMap();
            CreateMap<Screening, GetScreeningDto>().ReverseMap();
            CreateMap<Screening, UpdateScreeningDto>().ReverseMap();

            CreateMap<Seat, AddSeatDto>().ReverseMap();
            CreateMap<Seat, GetSeatDto>().ReverseMap();
            CreateMap<Seat, UpdateSeatDto>().ReverseMap();
            //

            // multiple-entity based mappings
            CreateMap<Movie, GetMovieDto>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor)))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre)))
                .ReverseMap();

            CreateMap<AddMovieDto, Movie>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres))
                .ReverseMap();

            CreateMap<AddMovieActorDto, MovieActor>().ReverseMap();
            CreateMap<AddMovieGenreDto, MovieGenre>().ReverseMap();
            //
        }
    }
}