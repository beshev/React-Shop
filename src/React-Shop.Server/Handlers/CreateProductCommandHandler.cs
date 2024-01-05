namespace React_Shop.Server.Handlers
{
    using Infrastructure.Common;
    using Infrastructure.Models;
    using MediatR;
    using React_Shop.Server.Commands;
    using Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProductCommandHandler(
        IProductService productService,
        IWebHostEnvironment webHostEnvironment) : ServiceBase, IRequestHandler<CreateProductCommand, InternalResult<ProductModel>>
    {
        private readonly IProductService _productService = productService;
        private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

        public async Task<InternalResult<ProductModel>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var image = request.Product.Image;
            image.Url = Path.Combine(_webHostEnvironment.ContentRootPath, "Resources", "Images", image.Name);

            var result = await _productService.CreateAsync(request.Product, cancellationToken);
            return Success(result);
        }
    }
}
