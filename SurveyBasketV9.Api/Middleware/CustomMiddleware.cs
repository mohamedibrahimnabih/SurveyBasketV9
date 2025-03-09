using System.Globalization;

namespace SurveyBasketV9.Api.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine("This is my request");

            await _next(context);

            Console.WriteLine("This is my response");
        }
    }
}
