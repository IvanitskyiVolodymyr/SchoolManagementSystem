using Application;
using FluentValidation.AspNetCore;
using Infrastructure.Data;
using System.Reflection;
using WebApi.Extentions;
using WebApi.Middleware;
using WebApi.Validators.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegisterInfrastructureServices();

//Register ApplicationServices
builder.Services.RegisterApplicationServices();

builder.Services.AddScoped<TasksValidators>();
builder.Services.AddScoped<CommentsValidator>();

//mapper
builder.Services.ConfigureMapping();

//Register Repositories
builder.Services.RegisterRepositories();

//Register JWT
builder.Services.ConfigureJwt(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        b => b.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

#pragma warning disable CS0618 // Type or member is obsolete
builder.Services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.ImplicitlyValidateChildProperties = true;
                    options.ImplicitlyValidateRootCollectionElements = true;
                    options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
#pragma warning restore CS0618 // Type or member is obsolete

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

app.UseCors("CorsPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
