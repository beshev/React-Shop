namespace Infrastructure.Profiler
{
    using AutoMapper;
    using Data.Entities;
    using Infrastructure.Models;

    public class ModelEntityMappingProfiler : Profile
    {
        public ModelEntityMappingProfiler()
        {
            CreateMap<ProductEntity, ProductModel>();

            CreateMap<ProductCreateModel, ProductEntity>();

            CreateMap<ImageCreateModel, ImageEntity>();

            CreateMap<ImageEntity, ImageModel>();
        }
    }
}
