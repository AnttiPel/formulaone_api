using FormulaOneAPI.Middlewares;
using FormulaOneAPI.Models.EDMs;
using FormulaOneAPI.Interfaces;
using FormulaOneAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables(env)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .Build();

builder.Services.AddAuthorization();
builder.Services.AddDbContext<FormulaContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DatabaseConnectionString")));

builder.Services.AddScoped<IDriverService, DriverService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
