using Cinema.DAL;
using Cinema.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Db Context
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
