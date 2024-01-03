namespace React_Shop.Server.Handlers
{
    using Infrastructure.Common;
    using Infrastructure.Models;
    using MediatR;
    using React_Shop.Server.Commands;
    using Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateProductCommandHandler(IProductService productService) : ServiceBase, IRequestHandler<CreateProductCommand, InternalResult<ProductModel>>
    {
        private readonly IProductService _productService = productService;

        public async Task<InternalResult<ProductModel>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.CreateAsync(request.Product, cancellationToken);
            return Success(product);
        }
    }
}
