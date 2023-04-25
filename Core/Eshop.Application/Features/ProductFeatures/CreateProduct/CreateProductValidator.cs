using FluentValidation;

namespace Eshop.Application.Features.ProductFeatures.CreateProduct
{
    public sealed class CreateProductValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(15);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(10).LessThanOrEqualTo(5000);
            RuleFor(x => x.Barcode).NotEmpty().Length(13);
            RuleFor(x => x.PLU).GreaterThanOrEqualTo(1).LessThanOrEqualTo(99999);
        }
    }
}