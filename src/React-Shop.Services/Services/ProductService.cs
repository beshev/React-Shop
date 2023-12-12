namespace Services
{
    using AutoMapper;
    using Data.Entities;
    using Data.Repositories;
    using Infrastructure.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductService(
        IProductRepository productRepository,
        IMapper mapper) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ProductModel> CreateAsync(ProductModel product, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<ProductEntity>(product);
            var result = await _productRepository.InsertAsync(entity, cancellationToken);

            return _mapper.Map<ProductModel>(result);
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync(CancellationToken cancellationToken)
        {
            var products = await _productRepository.WhereAsync(cancellationToken);
            var result = products.Select(entity => _mapper.Map<ProductModel>(entity));

            return result;
        }

        public async Task<int> DeleteAsync(string Id, CancellationToken cancellationToken)
        {
            return await _productRepository.DeleteManyAsync(x => x.Id.Equals(Id), cancellationToken);
        }
    }
}
