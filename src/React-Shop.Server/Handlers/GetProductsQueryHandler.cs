namespace React_Shop.Server.Handlers
{
    using Infrastructure.Common;
    using Infrastructure.Constants;
    using Infrastructure.Models;
    using MediatR;
    using React_Shop.Server.Queries;
    using Services;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class GetProductsQueryHandler(IProductService productService) : IRequestHandler<GetProductsQuery, InternalResult<IEnumerable<ProductModel>>>
    {
        private readonly IProductService _productService = productService;

        public async Task<InternalResult<IEnumerable<ProductModel>>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productService.GetAllAsync(cancellationToken);
            if (!products.Any())
            {
                return new InternalResult<IEnumerable<ProductModel>>("No content", InternalStatusCodesConstant.NoContent, "No products founded");
            }

            return new InternalResult<IEnumerable<ProductModel>>(products);
        }
    }
}
