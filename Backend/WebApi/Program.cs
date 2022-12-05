using Application;
using Infrastructure.Data;
using WebApi.Extentions;
using WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterInfrastructureServices();

//Register ApplicationServices
builder.Services.RegisterApplicationServices();

//mapper
builder.Services.ConfigureMapping();

//Register Repositories
builder.Services.RegisterRepositories();

//Register JWT
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
