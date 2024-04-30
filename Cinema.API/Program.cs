using Cinema.DAL;
using Cinema.DAL.Infrastructure;
using Cinema.DAL.Infrastructure.Interfaces;
using Cinema.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// context configuration and database connection
builder.Services.AddDbContext<CinemaContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Cinema.API")))
    .AddIdentity<User, UserRole>(config =>
    {
        config.Password.RequireNonAlphanumeric = false;
        config.Password.RequireDigit = true;
        config.Password.RequiredLength = 8;
        config.Password.RequireLowercase = true;
        config.Password.RequireUppercase = true;
    }).AddEntityFrameworkStores<CinemaContext>().AddDefaultTokenProviders();

// repositories

// infrastructure
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// services

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
