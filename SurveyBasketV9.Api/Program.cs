using Scalar.AspNetCore;
using SurveyBasketV9.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

//app.UseCustomMiddleware();

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("This is my request");

//    await next(context);

//    Console.WriteLine("This is my response");
//});

app.UseAuthorization();

app.MapControllers();

app.Run();
