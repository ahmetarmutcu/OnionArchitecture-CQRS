using Microsoft.AspNetCore.Builder;
using System.Reflection;

namespace OnionArchitecture.Application.Exceptions
{
    public static class ConfigureExceptionMiddleware
    {
        public static void ConfigureExceptionHandlingMiddleware(this IApplicationBuilder app)
        {
          

            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
