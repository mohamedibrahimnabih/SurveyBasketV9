using Scalar.AspNetCore;
using SurveyBasketV9.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices();

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
