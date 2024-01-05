namespace React_Shop.Server.Extentions
{
    using AutoMapper;
    using React_Shop.Server.Profiler;
    using Infrastructure.Profiler;

    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AddProfilers, typeof(ServiceCollectionExtentions).Assembly);

            return services;
        }

        private static void AddProfilers(IMapperConfigurationExpression mapperConfiguration)
        {
            mapperConfiguration.AddProfile<ModelEntityMappingProfiler>();
            mapperConfiguration.AddProfile<ApiModelsMappingProfile>();
        }
    }
}
