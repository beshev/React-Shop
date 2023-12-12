﻿namespace Infrastructure.Extentions
{
    using AutoMapper;
    using Infrastructure.Profiler;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterSettings<T>(this IServiceCollection services, IConfiguration configuration, string section = null) where T : class
        {
            var settings = Activator.CreateInstance<T>();
            configuration.GetSection(string.IsNullOrWhiteSpace(section) ? typeof(T).Name : section).Bind(settings);

            services.AddSingleton(settings);
            return services;
        }

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AddProfilers, typeof(ServiceCollectionExtensions).Assembly);

            return services;
        }

        private static void AddProfilers(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.AddProfile<ProducMappingProfiler>();
        }
    }
}
