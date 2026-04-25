using MediaVault.Interfaces;
using MediaVault.Services;
using MediaVault.Providers;
using MediaVault.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient<OmdbProvider>();
builder.Services.AddScoped<IOmdbProvider, OmdbProvider>();
builder.Services.AddSingleton<IMediaRepository, MediaRepository>();
builder.Services.AddScoped<IMediaService, MediaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.MapControllers();

app.Run();

