using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OnlineQuizSystem.API.Interfaces;
using OnlineQuizSystem.API.Services;
using OnlineQuizSystem.Business.Interfaces;
using OnlineQuizSystem.Business.Services;
using OnlineQuizSystem.Business.Validators;
using OnlineQuizSystem.Data;
using OnlineQuizSystem.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// ========== Repositories ==========
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
builder.Services.AddScoped<IQuizRepository, QuizRepository>();

// ========== Services ==========
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IInstructorService, InstructorService>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<OnlineQuizSystem.Business.Interfaces.IAuthenticationService, 
OnlineQuizSystem.Business.Services.AuthenticationService>();

// Token
builder.Services.AddScoped<ITokenProvider, JwtTokenProvider>();




builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =  JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    var jwtSettings = builder.Configuration.GetSection("JwtSettings");
    
    options.TokenValidationParameters = new()
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]!)
        )

        
    };
});
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Run();

