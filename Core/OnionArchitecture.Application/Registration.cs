using FluentValidation;
using FluentValidation.Resources;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Beheviors;
using OnionArchitecture.Application.Exceptions;
using System.Globalization;
using System.Reflection;

namespace OnionArchitecture.Application
{
    public static class Registration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddTransient<ExceptionMiddleware>();

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));
        }
    }
}
