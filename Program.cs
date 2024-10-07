//Environment variables are called
using DotNetEnv;
using Hotel.Data;
using Microsoft.EntityFrameworkCore;

Env.Load();

var DB_HOST = Environment.GetEnvironmentVariable("DB_HOST");
var DB_NAME = Environment.GetEnvironmentVariable("DB_NAME");
var DB_PORT = Environment.GetEnvironmentVariable("DB_PORT");
var DB_USERNAME = Environment.GetEnvironmentVariable("DB_USERNAME");
var DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD");


var stringConnection = $"server={DB_HOST};port={DB_PORT};database={DB_NAME};uid={DB_USERNAME};password={DB_PASSWORD}";

var builder = WebApplication.CreateBuilder(args);

//database connection
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseMySql(stringConnection, ServerVersion.Parse("8.0.20-mysql"));
});

// Add services to the container.

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
