using System.Globalization;

namespace SurveyBasketV9.Api.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("Request Log From Class");

            await _next(context);

            Console.WriteLine("Response Log From Class");
        }
    }
}
