namespace React_Shop.Server.Queries
{
    using Infrastructure.Common;
    using Infrastructure.Models;
    using MediatR;
    using System.Collections.Generic;

    internal class GetProductsQuery : IRequest<InternalResult<IEnumerable<ProductModel>>>
    {
    }
}
