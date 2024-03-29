﻿using Microsoft.Extensions.DependencyInjection;
using OnionArchitecture.Application.Interfaces.AutoMapper;
namespace OnionArchitecture.Mapper
{
    public static class Registration
    {
        public static void AddCustomMapper(this IServiceCollection services)
        {
            services.AddSingleton<IMapper, AutoMapper.Mapper>();
        }
    }
}
