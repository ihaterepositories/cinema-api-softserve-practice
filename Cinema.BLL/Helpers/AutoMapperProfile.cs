using System.Linq;
using AutoMapper;
using Cinema.Data.DTOs.ActorDTOs;
using Cinema.Data.DTOs.GenreDTOs;
using Cinema.Data.DTOs.MovieDTOs;
using Cinema.Data.Models;

namespace Cinema.BLL.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Actor, GetActorDto>().ReverseMap();
            CreateMap<Genre, GetGenreDto>().ReverseMap();
            CreateMap<Movie, GetMovieDto>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors.Select(ma => ma.Actor)))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres.Select(mg => mg.Genre)))
                .ReverseMap();

            CreateMap<AddMovieDto, Movie>()
                .ForMember(dest => dest.MovieActors, opt => opt.MapFrom(src => src.MovieActors))
                .ForMember(dest => dest.MovieGenres, opt => opt.MapFrom(src => src.MovieGenres))
                .ReverseMap();

            CreateMap<UpdateActorDto, Movie>().ReverseMap();
            CreateMap<AddMovieActorDto, MovieActor>().ReverseMap();
            CreateMap<AddMovieGenreDto, MovieGenre>().ReverseMap();
        }
    }
}
