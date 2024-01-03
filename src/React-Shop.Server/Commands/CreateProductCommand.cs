namespace React_Shop.Server.Commands
{
    using Infrastructure.Common;
    using Infrastructure.Constants;
    using Infrastructure.Models;
    using React_Shop.Server.Interfaces;

    public class CreateProductCommand : IValidatable<ProductModel>
    {
        public ProductModel Product { get; set; }

        public ErrorContext ErrorContext => new(CommonMessageConstants.CreateProducRequestFailed);
    }
}
