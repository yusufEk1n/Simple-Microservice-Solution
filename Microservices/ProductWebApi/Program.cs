using Microsoft.EntityFrameworkCore;
using ProductWebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

/* Database context dependency injection */
var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbUserId = Environment.GetEnvironmentVariable("DB_USERID");

var connectionString = $"Data Source={dbHost}; Initial Catalog={dbName}; Uid={dbUserId}; Pwd={dbPassword}";

builder.Services.AddDbContext<ProductDbContext>(options => options.UseMySQL(connectionString));

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
