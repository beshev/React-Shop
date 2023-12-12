namespace Infrastructure.Profiler
{
    using AutoMapper;
    using Data.Entities;
    using Infrastructure.Models;
    using System;

    internal class ProducMappingProfiler : Profile
    {
        public ProducMappingProfiler()
        {
            CreateMap<ProductEntity, ProductModel>()
                .ReverseMap();
        }
    }
}
