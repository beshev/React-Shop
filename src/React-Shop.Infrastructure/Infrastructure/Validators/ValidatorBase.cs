namespace Infrastructure.Validators
{
    using FluentValidation;
    using FluentValidation.Results;
    using Infrastructure.Constants;
    using System.Collections.Generic;

    public abstract class ValidatorBase<T> : AbstractValidator<T>
    {
        protected override bool PreValidate(ValidationContext<T> context, ValidationResult result)
        {
            if (EqualityComparer<T>.Default.Equals(context.InstanceToValidate, default))
            {
                context.AddFailure(typeof(T).Name, CommonMessageConstants.DefaulValadationInstance);
                return false;
            }

            return base.PreValidate(context, result);
        }
    }
}
