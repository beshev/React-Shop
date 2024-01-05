namespace React_Shop.Server.Profiler
{
    using AutoMapper;
    using Infrastructure.Models;
    using React_Shop.Server.Commands;
    using React_Shop.Server.Models;

    public class ApiModelsMappingProfile : Profile
    {
        public ApiModelsMappingProfile()
        {
            CreateMap<ProductCreateApiModel, CreateProductCommand>()
                .ForMember(dest => dest.Product, opt => opt.MapFrom(x => x));

            CreateMap<ProductCreateApiModel, ProductCreateModel>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom<ImageMappingResolver>());
        }
    }

    internal class ImageMappingResolver : IValueResolver<ProductCreateApiModel, ProductCreateModel, ImageCreateModel>
    {
        public ImageCreateModel Resolve(ProductCreateApiModel source, ProductCreateModel destination, ImageCreateModel destMember, ResolutionContext context)
        {
            if (source.Image == null)
                return null;

            // TODO: Check this again is there a better way?
            using var ms = new MemoryStream();
            source.Image.CopyToAsync(ms)
                .GetAwaiter()
                .GetResult();

            var result = new ImageCreateModel
            {
                Name = source.Image.FileName,
                Content = ms.ToArray()
            };

            return result;
        }
    }
}
