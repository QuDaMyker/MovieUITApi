using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieUIT.Model;
using MovieUIT.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MovieUITSettings>(builder.Configuration.GetSection(nameof(MovieUITSettings)));
builder.Services.AddSingleton<IMovieUITSettings>(sp => sp.GetRequiredService<IOptions<MovieUITSettings>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("MovieUITSettings:ConnectionString")));
builder.Services.AddScoped<IMovieTMDBService, MovieTMDBService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
