using OnlineQuizSystem.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.Run();

