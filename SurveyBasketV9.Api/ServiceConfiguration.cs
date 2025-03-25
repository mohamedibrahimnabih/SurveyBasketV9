using Mapster;
using MapsterMapper;
using SurveyBasketV9.Api.Services.IServices;
using SurveyBasketV9.Api.Services;
using SurveyBasketV9.Api.Validations;
using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace SurveyBasketV9.Api
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllers();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi();

            services.AddMapster()
                .AddInjection()
                .AddValidation();

            return services;
        }

        public static IServiceCollection AddMapster(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton<IMapper>(new Mapper(config));

            return services;
        }

        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddScoped<IPollService, PollService>();

            return services;
        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssemblyContaining<PollRequestValidator>();

            return services;
        }
    }
}
