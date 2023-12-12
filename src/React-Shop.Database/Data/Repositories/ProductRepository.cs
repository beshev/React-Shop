namespace Data.Repositories
{
    using Data.Entities;
    using Data.Models;
    using MongoDB.Driver;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ProductRepository(MongoDbSetting setting) : MongoRepository<ProductEntity>(setting), IProductRepository
    {
        public async Task<bool> UpdateOneAsync(ProductEntity product, CancellationToken cancellationToken)
        {
            var updateOptions = new UpdateOptions { IsUpsert = false };
            var updateDefinition = Builders<ProductEntity>.Update
                .Set(x => x.Name, product.Name)
                .Set(x => x.UpdatedOn, DateTime.UtcNow);

            var updateResult = await GetCollection().UpdateOneAsync(x => x.Id == product.Id, updateDefinition, updateOptions, cancellationToken);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public override Task<ProductEntity> InsertAsync(ProductEntity product, CancellationToken cancellationToken)
        {
            product.CreatedOn = DateTime.UtcNow;
            return base.InsertAsync(product, cancellationToken);
        }

        protected override IMongoCollection<ProductEntity> GetCollection()
        {
            return GetCollection<ProductEntity>(DataConstants.ReactShopDatabase, DataConstants.ProducsCollection);
        }
    }
}
