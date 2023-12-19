using Microsoft.AspNetCore.Diagnostics;
using MovieStore.WebApi.Business.Abstract;
using MovieStore.WebApi.Business.Concrete;
using MovieStore.WebApi.Business.ExceptionHandler;
using MovieStore.WebApi.Business.Logger;
using MovieStore.WebApi.Data.Abstract;
using MovieStore.WebApi.Data.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Automapper configuration
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

//Dependency Injection configuration

builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

builder.Services.AddScoped<IMovieService, MovieManager>();
builder.Services.AddScoped<IMovieRepo, MovieRepo>();

builder.Services.AddScoped<IDirectorService, DirectorManager>();
builder.Services.AddScoped<IDirectorRepo, DirectorRepo>();

builder.Services.AddScoped<IActorService, ActorManager>();
builder.Services.AddScoped<IActorRepo, ActorRepo>();

builder.Services.AddScoped<ICustomerService, CustomerManager>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();

builder.Services.AddScoped<IFavoriteGenreService, FavoriteGenreManager>();
builder.Services.AddScoped<IFavoriteGenreRepo, FavoriteGenreRepo>();

builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();





var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Exception Handing Middleware
app.UseExceptionHandlerMiddleware();


app.UseAuthorization();

app.MapControllers();



app.Run();




