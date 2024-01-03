namespace React_Shop.Server.Behaviors
{
    using Infrastructure.Common;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class ExeptionPipelineBehavior<T, K> : ServiceBase, IPipelineBehavior<T, InternalResult<K>>
    {
        public async Task<InternalResult<K>> Handle(T request, RequestHandlerDelegate<InternalResult<K>> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception)
            {
                // TODO: implement error handling logic
                throw;
            }
        }
    }
}
