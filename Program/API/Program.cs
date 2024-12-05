using FilmAnmeldelseApi.Data;
using FilmAnmeldelseApi.Interfaces;
using FilmAnmeldelseApi.Repository;
using FilmAnmeldelseApi.services;
using WebApp.services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddDbContext<DataContext>();  <- brug den senere
builder.Services.AddDbContext<FilmAnmeldelseContext>();
builder.Services.AddScoped<IFilmRepository, FilmRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IFilmService, FilmService>(); // Tilføj FilmService
builder.Services.AddScoped<IUserService, UserService>(); // Tilføj UserService
builder.Services.AddScoped<IFilmRepository, FilmRepository>(); // Tilføj FilmRepository
builder.Services.AddScoped<IUserRepository, UserRepository>(); // Tilføj UserRepository



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
