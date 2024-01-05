namespace React_Shop.Server.Behaviors
{
    using FluentValidation;
    using Infrastructure.Common;
    using MediatR;
    using React_Shop.Server.Interfaces;
    using System.Threading;
    using System.Threading.Tasks;

    public class FluentValidationPipelineBehavior<T, K>(IEnumerable<IValidator<T>> validators) : ServiceBase, IPipelineBehavior<T, InternalResult<K>>
        where T : IValidatable<K>
    {
        private const string ValidatiorsNotFoundErrorMessage = "Validatiors not found.";

        private readonly IEnumerable<IValidator<T>> _validators = validators;

        public async Task<InternalResult<K>> Handle(T request, RequestHandlerDelegate<InternalResult<K>> next, CancellationToken cancellationToken)
        {
            if (_validators is null || !_validators.Any())
            {
                return ValidationError<K>(request.ErrorContext.Title, ValidatiorsNotFoundErrorMessage);
            }

            // TODO: Add commad handler validator
            var validationErrors = _validators
                .Select(x => x.Validate(request))
                .SelectMany(x => x.Errors)
                .Where(x => x != null);

            if (validationErrors.Any())
            {
                return ValidationError<K>(request.ErrorContext.Title, validationErrors.Select(x => x.ErrorMessage));
            }

            return await next();
        }
    }
}
