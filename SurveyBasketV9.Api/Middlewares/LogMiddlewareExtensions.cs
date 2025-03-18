namespace SurveyBasketV9.Api.Middlewares
{
    public static class LogMiddlewareExtensions
    {
        public static IApplicationBuilder UseLog(
        this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }
    }
}
