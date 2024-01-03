namespace React_Shop.Server.Interfaces
{
    using Infrastructure.Common;
    using MediatR;

    public interface IValidatable<T> : IRequest<InternalResult<T>>
    {
        ErrorContext ErrorContext { get; }
    }
}
