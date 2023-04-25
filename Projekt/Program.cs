using Microsoft.EntityFrameworkCore;
using Projekt.Context;
using Projekt.Models;
using Projekt.Services.Film;
using Projekt.Services.Rent;
using Projekt.Services.User;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FilmContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("FilmContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IFilmService, FilmService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRentService, RentService>();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
