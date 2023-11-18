using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using QuizApp.Api.Data;
using QuizApp.Api.Handler;
using QuizApp.Api.Service.UserService;

var builder = WebApplication.CreateBuilder(args);
// Step 1: Add CORS service
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// JWT Authentication
builder.Services.AddCustomJwtAuthentication();
builder.Services.AddSingleton<JwtTokenHandler>();
//Service
builder.Services.AddScoped<IUserService, UserService>();
var app = builder.Build();
// Step 3: Use CORS middleware
app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();


app.Run();
