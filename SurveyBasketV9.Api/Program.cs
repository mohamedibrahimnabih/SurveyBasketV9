using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using Scalar.AspNetCore;
using SurveyBasketV9.Api.Middlewares;
using SurveyBasketV9.Api.Services;
using SurveyBasketV9.Api.Services.IServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<IMapper>(new Mapper(config));

builder.Services.AddScoped<IPollService, PollService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

//app.Use(async (context, next) =>
//{
//    Console.WriteLine("Request Log");

//    await next.Invoke(context);

//    Console.WriteLine("Response Log");
//});

//app.UseLog();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
