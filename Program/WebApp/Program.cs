using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using BlazorApp.Components;
using BlazorApp.Services;
using WebApplicationApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Tilføj DbContext med en forbindelse til databasen
//builder.Services.AddDbContext<ImageContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7104") });

// Registrér ImageService som en tjeneste
//builder.Services.AddScoped<Imgservices>();

builder.Services.AddScoped<ImageService>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

var app = builder.Build();

app.UseCors(c => c.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
