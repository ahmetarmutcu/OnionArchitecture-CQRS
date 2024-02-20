using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Persistence.Context;
using System.Reflection.Emit;

namespace OnionArchitecture.Persistence
{
    public static class Registration
    {
        public  static void AddPersistence(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => 
            opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")).EnableSensitiveDataLogging());
        }
    }
}
