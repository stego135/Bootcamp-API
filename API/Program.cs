using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore;
using System.Reflection;
using Bootcamp_API.Data;
using Microsoft.EntityFrameworkCore;
using Bootcamp_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Shiny Counter API",
        Description = "An ASP.NET Core Web API for managing shiny hunts",
        Contact = new OpenApiContact
        {
            Name = "Fiona Becker",
            Url = new Uri("https://www.ceiamerica.com/")
        }
    });
    options.EnableAnnotations();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services
    .AddEntityFrameworkSqlServer()
    .AddDbContext<PokemonContext>(p => p.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PokemonDB;"));

builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<HallOfFameService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Shiny Counter API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
