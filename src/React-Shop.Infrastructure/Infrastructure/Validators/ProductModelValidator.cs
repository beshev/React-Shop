namespace Infrastructure.Validators
{
    using FluentValidation;
    using Infrastructure.Models;

    public class ProductModelValidator : ValidatorBase<ProductModel>
    {
        public ProductModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
