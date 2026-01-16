using System.Reflection;
using Api_LojaTricotllure.Data;
using Api_LojaTricotllure.DependencyInjection;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);
var connectionString =
    $"Server={Environment.GetEnvironmentVariable("DB_SERVER")};" +
    $"Port={Environment.GetEnvironmentVariable("DB_PORT")};" +
    $"Database={Environment.GetEnvironmentVariable("DB_NAME")};" +
    $"Uid={Environment.GetEnvironmentVariable("DB_USER")};" +
    $"Pwd={Environment.GetEnvironmentVariable("DB_PASSWORD")};" +
    $"SslMode={Environment.GetEnvironmentVariable("DB_SSL")};";

builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddProjectDependencies();

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