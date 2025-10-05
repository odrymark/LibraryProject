using Api.Services;
using DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var allowedOrigin = builder.Configuration["FrontendUrl"] ?? "https://react-misty-meadow-8814.fly.dev"; 
const string AllowFrontendPolicy = "AllowFrontend";

builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("LibraryDbConn"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowFrontendPolicy,
        policy =>
        {
            policy.WithOrigins(allowedOrigin)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

builder.Services.AddScoped<ILibraryService, LibraryService>();
builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<LibraryDbContext>().Database.EnsureCreated();
}

app.UseOpenApi();
app.UseSwaggerUi();
app.UseCors(AllowFrontendPolicy);
app.MapControllers();
app.Run();
