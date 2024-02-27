using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Bases;
using OnionArchitecture.Application.Beheviors;
using OnionArchitecture.Application.Exceptions;
using OnionArchitecture.Application.Features.Products.Rules;
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

            services.AddRulesFromAssemblyContaining(assembly, typeof(BaseRules));
            services.AddTransient<ProductRules>();

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(assembly));

            services.AddValidatorsFromAssembly(assembly);
            ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("tr");

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehevior<,>));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RedisCacheBehevior<,>));
        }

        private static IServiceCollection AddRulesFromAssemblyContaining(
            this IServiceCollection services,
            Assembly assembly,
            Type type)
        {
            var types=assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type!=t).ToList();
            foreach (var item in types)
                services.AddTransient(item);

            return services;
        }
    }
}
