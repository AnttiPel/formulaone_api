using FormulaOneAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
