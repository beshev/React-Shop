namespace Services
{
    using Infrastructure.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllAsync(CancellationToken cancellationToken);

        Task<ProductModel> CreateAsync(ProductCreateModel product, CancellationToken cancellationToken);

        Task<int> DeleteAsync(string id, CancellationToken cancellationToken);
    }
}
