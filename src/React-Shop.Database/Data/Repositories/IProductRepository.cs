namespace Data.Repositories
{
    using Data.Entities;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<bool> UpdateOneAsync(ProductEntity product, CancellationToken cancellationToken);
    }
}
