using Application;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.DataAccess;
using Infrastructure.Data.Repositories;
using WebApi.Extentions;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ISqlDataAccess, SqlDataAccess>();

//Register ApplicationServices
builder.Services.RegisterApplicationServices();

//mapper
builder.Services.ConfigureMapping();

//Register Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Register JWT
//builder.Services.AddAuthentication();
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
