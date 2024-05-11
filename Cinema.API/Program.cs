using Cinema.BLL.Services;
using Cinema.BLL.Services.Interfaces;
using Cinema.DAL;
using Cinema.DAL.Infrastructure;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.DAL.Repositories;
using Cinema.DAL.Repositories.Interfaces;
using Cinema.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// context configuration and database connection
builder.Services.AddDbContext<CinemaContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Cinema.DAL")))
    .AddIdentity<User, UserRole>(config =>
    {
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireDigit = true;
        config.Password.RequiredLength = 8;
        config.Password.RequireLowercase = true;
        config.Password.RequireUppercase = true;
    }).AddEntityFrameworkStores<CinemaContext>().AddDefaultTokenProviders();

// AutoMapper 
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// services
builder.Services.AddScoped<IActorService, ActorService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IReservedSeatService, ReservedSeatService>();
builder.Services.AddScoped<IScreeningService, ScreeningService>();
builder.Services.AddScoped<ISeatService, SeatService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

// repositories
builder.Services.AddScoped<IActorRepository, ActorRepository>();
builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieActorRepository, MovieActorRepository>();
builder.Services.AddScoped<IMovieGenreRepository, MovieGenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservedSeatRepository, ReservedSeatRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IScreeningRepository, ScreeningRepository>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

// infrastructure
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Redis-Caching
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "redis-cache:6379";
    options.InstanceName = "Cinema";

});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
