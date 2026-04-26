using MediaVault.Interfaces;
using MediaVault.Services;
using MediaVault.Providers;
using MediaVault.Repositories;
using MediaVault.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MediaVaultDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
builder.Services.AddHttpClient<OmdbProvider>();
builder.Services.AddScoped<IOmdbProvider, OmdbProvider>();
builder.Services.AddScoped<IMediaRepository, SqliteMediaRepository>();
builder.Services.AddScoped<IMediaService, MediaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DevCors", policy =>
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors("DevCors");
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

