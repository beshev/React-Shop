namespace Data.Repositories
{
    using Data.Models;
    using LinqKit;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class MongoRepository<T>(MongoDbSetting setting) : IRepository<T>
        where T : class
    {
        private const int LimitMinValue = 1;
        private const int LimitMaxValue = 10000;

        private readonly MongoClient _client = new(setting.ConnectionString);

        public virtual async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetCollection().AsQueryable().AnyAsync(predicate.Expand(), cancellationToken);
        }

        public virtual async Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetCollection().AsQueryable().CountAsync(predicate.Expand(), cancellationToken);
        }

        public virtual async Task<int> DeleteManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return (int)(await GetCollection().DeleteManyAsync(predicate.Expand(), cancellationToken)).DeletedCount;
        }

        public virtual async Task<T> InsertAsync(T obj, CancellationToken cancellationToken)
        {
            await GetCollection().InsertOneAsync(obj);
            return obj;
        }

        public virtual async Task<IEnumerable<T>> WhereAsync(CancellationToken cancellationToken)
        {
            return await GetCollection().AsQueryable().ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetCollection().AsQueryable().Where(predicate.Expand()).ToListAsync(cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, int limit, int offset, CancellationToken cancellationToken)
        {
            var validateLimit = limit >= LimitMinValue && limit <= LimitMaxValue ? limit : LimitMaxValue;
            return await GetCollection().AsQueryable().Where(predicate.Expand()).Skip(offset).Take(validateLimit).ToListAsync(cancellationToken);
        }

        protected abstract IMongoCollection<T> GetCollection();

        protected virtual IMongoCollection<K> GetCollection<K>(string database, string collection)
        {
            return _client
                .GetDatabase(database)
                .GetCollection<K>(collection);
        }
    }
}
