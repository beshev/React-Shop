namespace Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IRepository<T>
        where T : class
    {
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task<int> CountAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task<T> InsertAsync(T obj, CancellationToken cancellationToken);

        Task<IEnumerable<T>> WhereAsync(CancellationToken cancellationToken);

        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);

        Task<IEnumerable<T>> WhereAsync(Expression<Func<T, bool>> predicate, int limit, int offset, CancellationToken cancellationToken);

        Task<int> DeleteManyAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
    }
}
